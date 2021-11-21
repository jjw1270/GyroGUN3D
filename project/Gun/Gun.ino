const int trigPin = 3;     //btn
const int itemPin = 5;   //btn
const int act = 8;         //솔레노이드 액추에이터


void setup() {
  pinMode(trigPin, INPUT_PULLUP);
  pinMode(itemPin, INPUT_PULLUP);
  pinMode(act, OUTPUT);
  Serial.begin(9600);
}

boolean trigState = false;
boolean itemState = false;

void loop() {
  int trig = digitalRead(trigPin);
  int item = digitalRead(itemPin);
  String RV = "";
  
  if(Serial.available()){
    RV = Serial.readStringUntil('\n');
  }

  if(RV != "R"){
    if (trig == HIGH){    //한 번 발사 후 다시 떼어야 발사가능
      if(trigState == false){
        Serial.println("F");
        //Serial.flush();
        //delay(10);
        digitalWrite(act, HIGH);
        delay(100);
        digitalWrite(act, LOW);
        delay(200);
        trigState = true;
      }
    }
    else if(trig == LOW)
      trigState = false;
  }
  else{
    delay(5000);   //재장전 시간
  }


  if (item == HIGH){       //아이템 사용버튼
    if(itemState == false){    //한 번 사용 후 다시 떼어야 사용가능
      Serial.println("I");
      //delay(10);
      itemState = true;
    }
  }
  else if(item == LOW)
    itemState = false;
}
