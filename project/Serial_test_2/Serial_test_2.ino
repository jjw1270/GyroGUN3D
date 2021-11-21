//XXXXXXXXXXXXXXXXXXXX



const int trigPin = 5;     //btn
const int LED = 5;
const int ReloadPin = 6;

void setup() {
  Serial.begin(9600);
  pinMode(trigPin, INPUT_PULLUP);
  pinMode(LED, OUTPUT);
  pinMode(ReloadPin, INPUT_PULLUP);
}


int Bullet = 5;
int Bullet_tmp = 0;

void loop() {
  int trig = digitalRead(trigPin);
  int Bullet_State = digitalRead(BulletPin);
  boolean tmp = false;
  if(Serial.available()){
    //if (Bullet_State == HIGH){
      Serial.print("Number of Bullet : ");
      Bullet = int(Serial.read());
      Serial.println(Bullet);
      delay(100);
    //}
  }
  if(Bullet >= Bullet_tmp){
    if (trig == HIGH) {
      Serial.println("F");
      Bullet_tmp++;
      //솔레노이드 액추에이터
      delay(300);
    }
  }
  else{
    Serial.println("Reloading");
    Bullet_tmp = 0;
    digitalWrite(LED,HIGH);
    delay(3000);
    digitalWrite(LED, LOW);
  }
}
