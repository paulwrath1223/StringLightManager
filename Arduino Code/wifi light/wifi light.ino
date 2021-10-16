#include <Adafruit_NeoPixel.h>
#include <ESP8266WiFi.h>
#include <FirebaseESP8266.h>


//Provide the token generation process info.
#include <addons/TokenHelper.h>

//Provide the RTDB payload printing info and other helper functions.
#include <addons/RTDBHelper.h>

/* 1. Define the WiFi credentials */
#define WIFI_SSID "WIFI910"
#define WIFI_PASSWORD "1cadenas"

/* 2. Define the API Key */
#define API_KEY "AIzaSyBvzbSDl_9Z58G4cXnaFJIuH1MT5uUOmkw"

/* 3. Define the RTDB URL */
#define DATABASE_URL "https://light-data1-default-rtdb.firebaseio.com/" //<databaseName>.firebaseio.com or <databaseName>.<region>.firebasedatabase.app

/* 4. Define the user Email and password that already registered or added in your project */
#define USER_EMAIL "paul@fornage.net"
#define USER_PASSWORD "Paulrf99"

//Define Firebase Data object
FirebaseData fbdo;

FirebaseAuth auth;
FirebaseConfig config;

unsigned long sendDataPrevMillis = 0;

unsigned long count = 0;


String basePath = "/Arduino0";


#define PIN 0


Adafruit_NeoPixel pixels(1, PIN, NEO_GRB + NEO_KHZ800);


int mode = 0; // 0 means solic color, 1 means wave.
int numPixels = 1;
int r;
int g;
int b;
int numColors;
int updateCounter;

String path;
String modePath;
String lightLengthPath;
String colorLengthPath;
String colorPath;
String updatePath;

int waveOffset = 0;

uint32_t* colorList = 0;

void setup()
{
  updatePath = basePath + "/update";
  modePath = basePath + "/mode";
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

  /* Assign the api key (required) */
  config.api_key = API_KEY;

  /* Assign the user sign in credentials */
  auth.user.email = USER_EMAIL;
  auth.user.password = USER_PASSWORD;

  /* Assign the RTDB URL (required) */
  config.database_url = DATABASE_URL;

  /* Assign the callback function for the long running token generation task */
  config.token_status_callback = tokenStatusCallback; //see addons/TokenHelper.h

  Firebase.begin(&config, &auth);

  //Comment or pass false value when WiFi reconnection will control by your code or third party library
  Firebase.reconnectWiFi(true);

  Firebase.setDoubleDigits(5);

  numPixels = Firebase.getInt(fbdo, lightLengthPath);

  updateCloud()
}

void loop()
{
  if(updateCounter > 1000)
  {
    updateCloud()
    updateCounter = 0;
  }
  //Flash string (PROGMEM and  (FPSTR), String,, String C/C++ string, const char, char array, string literal are supported
  //in all Firebase and FirebaseJson functions, unless F() macro is not supported

  if(mode==0) // set color mode
  {
    for(int i=0; i<numPixels; i++) { // For each pixel...

    // pixels.Color() takes RGB values, from 0,0,0 up to 255,255,255
    // Here we're using a moderately bright green color:

    pixels.setPixelColor(i, colorList[(i % numColors)]);

    pixels.show();   // Send the updated pixel colors to the hardware.

    }
  }
  else if(mode==1) // wave mode
  {
    if( !(waveOffset < numColors))
    {
      waveOffset = 0;
    }
    for(int i=0; i<numPixels; i++) { // For each pixel...

    // pixels.Color() takes RGB values, from 0,0,0 up to 255,255,255
    // Here we're using a moderately bright green color:

    pixels.setPixelColor(i, colorList[((i + waveOffset) % numColors)]);

    pixels.show();   // Send the updated pixel colors to the hardware.
    waveOffset++;
    }
  }
  updateCounter++;
}


void updateCloud()
{
    update = Firebase.getInt(fbdo, updatePath)
    if(update == 1)
    {
        mode = Firebase.getInt(fbdo, modePath);
        numColors = Firebase.getInt(fbdo, colorLengthPath);

        if (colorList != 0)
        {
          delete [] colorList;
        }
        colorList = new uint32_t [numPixels];

        numPixels = Firebase.getInt(fbdo, lightLengthPath);
        pixels.updateLength(numPixels);

        for(int counter = 0; counter<numColors; counter++)
        {
          path = colorPath + String(counter) + "/";
          r = Firebase.getInt(fbdo, path+"r/");
          g = Firebase.getInt(fbdo, path+"g/");
          b = Firebase.getInt(fbdo, path+"b/");
          colorList[counter] = pixels.Color(r, g, b);
        }
        Firebase.setInt(fbdo, updatePath, 0);
    }
}
































/// PLEASE AVOID THIS ////

//Please avoid the following inappropriate and inefficient use cases
/**
 * 
 * 1. Call get repeatedly inside the loop without the appropriate timing for execution provided e.g. millis() or conditional checking,
 * where delay should be avoided.
 * 
 * Everytime get was called, the request header need to be sent to server which its size depends on the authentication method used, 
 * and costs your data usage.
 * 
 * Please use stream function instead for this use case.
 * 
 * 2. Using the single FirebaseData object to call different type functions as above example without the appropriate 
 * timing for execution provided in the loop i.e., repeatedly switching call between get and set functions.
 * 
 * In addition to costs the data usage, the delay will be involved as the session needs to be closed and opened too often
 * due to the HTTP method (GET, PUT, POST, PATCH and DELETE) was changed in the incoming request. 
 * 
 * 
 * Please reduce the use of swithing calls by store the multiple values to the JSON object and store it once on the database.
 * 
 * Or calling continuously "set" or "setAsync" functions without "get" called in between, and calling get continuously without set 
 * called in between.
 * 
 * If you needed to call arbitrary "get" and "set" based on condition or event, use another FirebaseData object to avoid the session 
 * closing and reopening.
 * 
 * 3. Use of delay or hidden delay or blocking operation to wait for hardware ready in the third party sensor libraries, together with stream functions e.g. Firebase.readStream and fbdo.streamAvailable in the loop.
 * 
 * 
 * Please use non-blocking mode of sensor libraries (if available) or use millis instead of delay in your code.
 * 
 */