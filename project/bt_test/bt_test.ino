#include <SoftwareSerial.h>
SoftwareSerial BTSerial(2, 3);   //bluetooth module Tx:Digital 2 Rx:Digital 3
const int trigPin = 4;     //btn

void setup() {
  Serial.begin(9600);
  BTSerial.begin(9600);
  pinMode(trigPin, INPUT_PULLUP);
}

void loop() {

  int trig = digitalRead(trigPin);

  //if (trig == HIGH) Serial.println("FIRE");
  
  if (BTSerial.available()){
    Serial.write(BTSerial.read());
  }
  if (Serial.available()){
    if(trig == HIGH){
      BTSerial.println(1);
      delay(400);
    }
  }
}
