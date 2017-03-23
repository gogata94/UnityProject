//test
int data = 0;
String consoleInputNumber;
char set[10];
 
void setup() {
  Serial.begin(9600,SERIAL_8O1);  // start serial for output
  pinMode(A1, INPUT);
  pinMode(A0, INPUT);
  
  
}

void loop() {
  if (Serial.available() > 0) {
   Serial.readBytes(set,1);
   if (set[0] == 'A') {
      data = analogRead(A0);   
      Serial.println(data);
      data = analogRead(A1);
      Serial.println(data);  
      delay(50);
    }
  } else { }
  set[0]='0';
}
