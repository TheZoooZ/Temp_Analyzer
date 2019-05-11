#include <OneWire.h>
#include <DS18B20.h>

OneWire onewire(2);
DS18B20 sensors(&onewire);

byte sensorAddress[8];

void setup() {
  Serial.begin(9600);
  while(onewire.search(sensorAddress)){
    if (sensorAddress[0] != 0x28)
      continue;
  }
  sensors.begin(10);
}

void loop() {
  sensors.request(sensorAddress);
  while(!sensors.available());
  float temperature = sensors.readTemperature(sensorAddress);
  Serial.println(temperature);
  delay(10000);

}
