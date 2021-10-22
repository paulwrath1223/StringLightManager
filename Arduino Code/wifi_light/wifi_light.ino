#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <FirebaseESP8266.h>

#include <addons/TokenHelper.h>

#include <addons/RTDBHelper.h>

#define WIFI_SSID "PHS"
#define WIFI_PASSWORD "CONNECT2012"



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
int numColors = 1;
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

uint32_t colorList[1];

void updateCloud()

{
    Serial.print("COLOR OF (200, 100, 100)");
    Serial.println(pixels.Color(200, 100, 100));
    Serial.println("timing shit idek");
    while(!(Firebase.ready() && (millis() - sendDataPrevMillis > 15000 || sendDataPrevMillis == 0)))
    {
      delay(1);
      Serial.print(".");
    }
    int tempUpdate = 0;
    sendDataPrevMillis = millis();
    Serial.println("database query began");
    Firebase.getInt(fbdo, updatePath, &tempUpdate);
    update = tempUpdate;

    if(update == 1)
    {
        Serial.println("update is true");
        float tempSpeed = 0;
        Firebase.getFloat(fbdo, speedPath, &tempSpeed);
        speed = tempSpeed;
//        Serial.printf("Get float... %s\n", Firebase.getFloat(fbdo, speedPath, &speed) ? String(fbdo.to<float>()).c_str() : fbdo.errorReason().c_str());            

        
        lastNumColors = numColors;
        int tempNumColors = 0;
        Firebase.getInt(fbdo, colorLengthPath, &tempNumColors);
        numColors = 1;
        if( ! (lastNumColors == numColors))
        {
            if (colorList != 0)
            {
              delete [] colorList;
            }
            colorList = new uint32_t[numPixels];
        }
        int tempNumPixels = 0;
        Firebase.getInt(fbdo, lightLengthPath, &tempNumPixels);
        numPixels = tempNumPixels;

        pixels.updateLength(numPixels);
        
        for(int counter = 0; counter<numColors; counter++)
        {
          path = colorPath + String(counter) + "/";
          int tr = 0;
          Firebase.getInt(fbdo, path+"r/", &tr);
          int tg = 0;
          Firebase.getInt(fbdo, path+"g/", &tg);
          int tb = 0;
          Firebase.getInt(fbdo, path+"b/", &tb);

          
          Serial.println(" color: ");
          Serial.print("  r: ");
          Serial.println(tr);
          Serial.print("  g: ");
          Serial.println(tg);
          Serial.print("  b: ");
          Serial.println(tb);
          Serial.print("final: ");
          Serial.println(pixels.Color(tr, tg, tb));
          colorList[counter] = pixels.Color(tr, tg, tb);
        }

        Firebase.setInt(fbdo, updatePath, 0);
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

  Serial.println("before update");
  updateCloud();
  Serial.println("Finished with setup");

}

void loop()
{
  Serial.println("loop started");
  if(updateCounter > 1000)
  {
    updateCloud();
    updateCounter = 0;
  }
  Serial.println("after update counter");
  //Flash string (PROGMEM and  (FPSTR), String,, String C/C++ string, const char, char array, string literal are supported
  //in all Firebase and FirebaseJson functions, unless F() macro is not supported

  timing += speed;
  Serial.println("timing done");
  if(timing > 1)
  {
    timing-=1;
    waveOffset++;    
  }  
  if( !(waveOffset < numColors))  // >=
  {
    waveOffset = 0;
  }
  Serial.println("pixel update loop");
  for(int i=0; i<numPixels; i++)  // For each pixel...
  {
      Serial.print("in loop at i = ");
      Serial.println(i);
      Serial.print("color to display: ");
      Serial.println(colorList[((i + waveOffset) % numColors)]);

      
      pixels.setPixelColor(i, colorList[((i + waveOffset) % numColors)]); // THESE LINES HAVE BIG FUCK UP
      pixels.show();   // Send the updated pixel colors to the hardware.
      Serial.print("end loop loop at i = ");
      Serial.println(i);
  }
  updateCounter++;
}


/*
--------------- CUT HERE FOR EXCEPTION DECODER ---------------

Exception (0):
epc1=0x40106f7e epc2=0x00000000 epc3=0x00000000 excvaddr=0x00000000 depc=0x00000000

>>>stack>>>

ctx: cont
sp: 3ffffde0 end: 3fffffc0 offset: 0190
3fffff70:  3ffef5dc 3ffeee78 3ffef690 40205226  
3fffff80:  3ffeede4 11258b0a 00000000 feefeffe  
3fffff90:  feefeffe feefeffe feefeffe 3ffef73c  
3fffffa0:  3fffdad0 00000000 3ffef728 4021910c  
3fffffb0:  feefeffe feefeffe 3ffe8658 40100e5d  
<<<stack<<<

--------------- CUT HERE FOR EXCEPTION DECODER ---------------

 ets Jan  8 2013,rst cause:2, boot mode:(3,7)

load 0x4010f000, len 3460, room 16 
tail 4
chksum 0xcc
load 0x3fff20b8, len 40, room 4 
tail 4
chksum 0xc9
csum 0xc9
v00082e80
~ld
*/
