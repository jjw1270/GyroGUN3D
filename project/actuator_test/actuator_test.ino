const int trigPin = 5;     //btn
const int act = 4;       //솔레노이드 액추에이터

void setup() {
  pinMode(trigPin, INPUT_PULLUP);
  pinMode(act, OUTPUT);
}

void loop() {
  int trig = digitalRead(trigPin);
  if (trig == HIGH) {
    digitalWrite(act, HIGH);
    delay(200);
    digitalWrite(act, LOW);
    delay(200);
  }
}
