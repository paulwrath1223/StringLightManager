#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <FirebaseESP8266.h>

#include <addons/TokenHelper.h>

#include <addons/RTDBHelper.h>

#define WIFI_SSID "WIFI910"
#define WIFI_PASSWORD "1cadenas"



/* 3. Define the RTDB URL */
#define DATABASE_URL "https://light-data1-default-rtdb.firebaseio.com/" 
#define DATABASE_SECRET "xnsxVJEbZchsxN2XPCkxAPhlZXdvWBt318oq98jh"


//Define Firebase Data object
FirebaseData fbdo;

FirebaseAuth auth;
FirebaseConfig config;



unsigned long sendDataPrevMillis = 0;

String basePath = "/Arduino0";


#define PIN 2


Adafruit_NeoPixel pixels(1, PIN, NEO_GRB + NEO_KHZ800);


float speed = 0; // 0 means solic color, 1 means wave.
int numPixels = 1;
int r;
int g;
int b;
int numColors;
int updateCounter;
int lastNumColors;
float timing = 0;
int update = 1;

String path;
String speedPath;
String lightLengthPath;
String colorLengthPath;
String colorPath;
String updatePath;

int waveOffset = 0;

uint32_t* colorList = 0;

void updateCloud()
{
    Serial.println("timing shit idek");
    while(!(Firebase.ready() && (millis() - sendDataPrevMillis > 15000 || sendDataPrevMillis == 0))
    {
      delay(1);
      Serial.print(".");
    }
    sendDataPrevMillis = millis();
    Serial.println("database query began");
    Firebase.getInt(fbdo, updatePath, update);
    if(update == 1)
    {
        Serial.println("update is true");
        Firebase.getInt(fbdo, speedPath, speed);            
        
        lastNumColors = numColors;
        Firebase.getInt(fbdo, colorLengthPath, numColors);
        if( ! (lastNumColors == numColors))
        {
            if (colorList != 0)
            {
              delete [] colorList;
            }
            colorList = new uint32_t [numPixels];
        }
        Firebase.getInt(fbdo, lightLengthPath, numPixels);
        pixels.updateLength(numPixels);

        for(int counter = 0; counter<numColors; counter++)
        {
          path = colorPath + String(counter) + "/";
            
          Firebase.getInt(fbdo, path+"r/", r);
          Firebase.getInt(fbdo, path+"g/", g);
          Firebase.getInt(fbdo, path+"b/", b);
            
          colorList[counter] = pixels.Color(r, g, b);
        }
        Firebase.setInt(fbdo, updatePath, false);
    }
    Serial.println("database query done :");
    Serial.print("speed: ");
    Serial.println(speed);
    Serial.print("numColors: ");
    Serial.println(numColors);
    Serial.print("numPixels: ");
    Serial.println(numPixels);

}


void setup()
{
  updatePath = basePath + "/update";
  speedPath = basePath + "/speed";
  lightLengthPath = basePath + "/numLights";
  colorLengthPath = basePath + "/colorLength";
  colorPath = basePath+"/colors";

  pixels.begin(); // INITIALIZE NeoPixel strip object (REQUIRED)
  Serial.begin(115200);

  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("Connecting to Wi-Fi");
  while (WiFi.status() != WL_CONNECTED)
  {
    Serial.print(".");
    delay(300);
  }
  Serial.println();
  Serial.print("Connected with IP: ");
  Serial.println(WiFi.localIP());
  Serial.println();

  Serial.printf("Firebase Client v%s\n\n", FIREBASE_CLIENT_VERSION);


  /* Assign the RTDB URL (required) */
  config.database_url = DATABASE_URL;
  config.signer.tokens.legacy_token = DATABASE_SECRET;

  /* Assign the callback function for the long running token generation task */
  config.token_status_callback = tokenStatusCallback; //see addons/TokenHelper.h

  Firebase.setMaxRetry(fbdo, 3);

  Firebase.reconnectWiFi(true);

  Firebase.begin(&config, &auth);


  updateCloud();
  Serial.println("Finished with setup");

}

void loop()
{
  if(updateCounter > 1000)
  {
    updateCloud();
    updateCounter = 0;
  }
  //Flash string (PROGMEM and  (FPSTR), String,, String C/C++ string, const char, char array, string literal are supported
  //in all Firebase and FirebaseJson functions, unless F() macro is not supported

  timing += speed;
  if(timing > 1)
  {
    timing-=1;
    waveOffset++;    
  }  
  if( !(waveOffset < numColors))  // >=
  {
    waveOffset = 0;
  }
  for(int i=0; i<numPixels; i++)  // For each pixel...
  {
      pixels.setPixelColor(i, colorList[((i + waveOffset) % numColors)]);
      pixels.show();   // Send the updated pixel colors to the hardware.
  }
  updateCounter++;
}
