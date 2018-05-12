#include <SoftwareSerial.h>

SoftwareSerial esp_serial(4, 2); // RX | TX

void setup()
{
  Serial.begin(9600);
  esp_serial.begin(9600);
}

void loop()
{
  while(esp_serial.available())
  {
    Serial.write(esp_serial.read());
  }

  if(Serial.available())
  {
    esp_serial.write(Serial.read());
  }
}

