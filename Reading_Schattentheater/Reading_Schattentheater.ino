
//----------------------------< LIBRARIES ☲ >------------------------------------------

#include <Wire.h>
#include <SPI.h>
#include <Adafruit_PN532.h> 


// ---------------------------< VARIABLEN/ ARRAYS ✘ >----------------------------------

int Rapunzel[32] = {82,97,112,117,110,122,101,108,0,0,0};           //Hier kommen dann die Werte der Buchstaben rein (kein Hex)
int Rotkaeppchen[32] = {82,111,116,107,97,101,112,112,104,101,110};

int Identification[32];

boolean StoryRap;
boolean StoryRot;
boolean CheckRap = true;
boolean CheckRot = true;

// --------------------------< RFID READER ▋ >-----------------------------------------

#define PN532_IRQ   (6)
#define PN532_RESET (3)  // Not connected by default on the NFC Shield

// Or use this line for a breakout or shield with an I2C connection:
Adafruit_PN532 nfc(PN532_IRQ, PN532_RESET);

#if defined(ARDUINO_ARCH_SAMD)
   #define Serial SerialUSB
#endif

//----------------------------< VOID SETUP ➤ >------------------------------------------
void setup(void) {
  #ifndef ESP8266
    while (!Serial); 
  #endif
  Serial.begin(115200); //115200 9600
 // Serial.println("Hello!");


  nfc.begin();

  uint32_t versiondata = nfc.getFirmwareVersion();
  if (! versiondata) {
    Serial.print("Didn't find PN53x board");
    while (1); // halt
  }
  // Got ok data, print it out!
  //Serial.print("Found chip PN5"); Serial.println((versiondata>>24) & 0xFF, HEX); 
 // Serial.print("Firmware ver. "); Serial.print((versiondata>>16) & 0xFF, DEC); 
  //Serial.print('.'); Serial.println((versiondata>>8) & 0xFF, DEC);
  
  // configure board to read RFID tags
  nfc.SAMConfig();
  
 // Serial.println("Waiting for an ISO14443A Card ...");
}
//-------------------------< VOID LOOP ∞ >----------------------------------------------

void loop(void) {
  uint8_t success;
  uint8_t uid[] = { 0, 0, 0, 0, 0, 0, 0 };  // Buffer to store the returned UID
  uint8_t uidLength;                        // Length of the UID (4 or 7 bytes depending on ISO14443A card type)

    
  // Wait for an NTAG203 card.  When one is found 'uid' will be populated with
  // the UID, and uidLength will indicate the size of the UUID (normally 7)
  success = nfc.readPassiveTargetID(PN532_MIFARE_ISO14443A, uid, &uidLength);

  
  //-----------------------< SUCCESS ✔ >-----------------------------------------------
  
  //-----------< Anfangsgelaber 💬 >-------
  if (success) {
    // Display some basic information about the card
  // Serial.println("Found an ISO14443A card");
  // Serial.print("  UID Length: ");Serial.print(uidLength, DEC);Serial.println(" bytes");
  //  Serial.print("  UID Value: ");
  //  nfc.PrintHex(uid, uidLength);
  //  Serial.println("");


//-----------< Zeilen durchgehen ⬇ >-------
    
    if (uidLength == 7)
    {
      uint8_t data[32];

         
  

      for (uint8_t i = 4; i < 15; i++) //hier wird von 4 bis S.14 durchgezählt. Auf den Ersten 4 Seiten steht nur die UID, die für uns nicht relevant ist
      {
        success = nfc.ntag2xx_ReadPage(i, data);   
        
//-----------< Speichern der Daten 💾 >------  
      
       Identification[0] = data[0]; // Die erste Stelle von Data wird im Array Identification gespeichert. Da eine Seite (mit je 4 bytes) mit 4x dem selben buchstaben besetzt wurde, lässt sich hier auch immer einfach eine Spalte auslesen.
     
      // Serial.print(Identification[0]);

       {
       
       // Data wird hier >nicht< als Hexcode gespeichert, da es sonst komplizierter wäre mit den Buchstaben
      


        if (Rapunzel[i-4] == Identification[0])
      {
        StoryRap = true;
      }
      else {
        CheckRap = false;
        StoryRap = false;
        //Serial.println("Rapunzel nicht erkannt");
      }
    
    if (StoryRap == true)
    {
      //Serial.println("Rapunzel erkannt");                    
    }

    if (Rotkaeppchen[i-4] == Identification[0])
      {
        StoryRot = true;
      }
      else {
        CheckRot = false;
        StoryRot = false;
        //Serial.println("Rotkaeppchen nicht erkannt");
      }
    
    if (StoryRot == true)
    {
      //Serial.println("Rotkaeppchen erkannt");                    
    }
     // Serial.print(data[0]& 0xff, HEX);
     // Rotkaeppchen HEX 52 6f 74 6b 61 65 70 70 63 68 65 6e
     // Rapunzel HEX 52 61 70 75 6e 7a 65 6c  

      }
    
      
      /*  for ( int i = 0; i < 4; i++){    
        //Serial.print(data[i]& 0xff, HEX);

          // Dump the page data
         // nfc.PrintHexChar(data,4);        // Die Zahl steht für die Zahl der bytes und somit Spalten, die dargestellt werden
         //                                 PrintHex gibt nur den HexCode der gespeicherten Buchstaben aus, PrintHexChar gibt HexCode + die umgewandelten Buchstaben aus
        } */
        } // --------------------------------- End for


     
    //}
 
    
    
    if (CheckRot == true ){
      Serial.println("Rotkaeppchen erkannt");
    //  Serial.println("Rotkäppchen abspielen");
    //  Serial.println("----Warten auf Update----");
    }

    if (CheckRap == true){
      Serial.println("Rapunzel erkannt");
    //  Serial.println("Rapunzel abspielen");
    //  Serial.println("----Warten auf Update----");
    }

    if (CheckRap == true && CheckRot == false){
      
      CheckRot = true;
    }

    if (CheckRap == false && CheckRot == true){
      
      CheckRap = true;
      
    }
    
    // Wait a bit before trying again
   // Serial.println("\n\nSend a character to scan another tag!");
    Serial.flush();
 /*   while (!Serial.available());
    while (Serial.available()) {
    Serial.read();
    }
    Serial.flush();    */
  }  
  delay(9000);
  }}
