const int trigPin = 4;     //btn
const int LED = 5;


void setup() {
  Serial.begin(9600);
  pinMode(trigPin, INPUT_PULLUP);
  pinMode(LED, OUTPUT);
}

void loop() {
  int trig = digitalRead(trigPin);
  String RV = "";
  if(Serial.available()){
    RV = Serial.readStringUntil('\n');
  }
  if (trig == HIGH) {
    Serial.println("F");
    //솔레노이드 액추에이터
    delay(400);
  }
  if(RV == "R"){
    //Serial.println("Reloading");
    digitalWrite(LED,HIGH);
    delay(5000);
    digitalWrite(LED, LOW);
  }
}
