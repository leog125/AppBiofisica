#include <Keypad.h>
int dataPin = 3;            // Any pwm pin out you want to connect to the transmitter DATA input

const byte rowsCount = 4;
const byte columsCount = 3;
char keys[rowsCount][columsCount] = {
   { '1','2','3' },
   { '4','5','6' },
   { '7','8','9' },
   { '*','0','#' }
};
const byte rowPins[rowsCount] = { 11, 10, 9, 8 };
const byte columnPins[columsCount] = { 7, 6, 5 };
Keypad keypad = Keypad(makeKeymap(keys), rowPins, columnPins, rowsCount, columsCount);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(dataPin, OUTPUT); // any output pin 
  
}

void loop() {
char key;
  key = keypad.getKey();
  
  if (key == '7') {
    Serial.println(key);    
    for (int i=0; i<5; i++) {
      transmitter();
      delay(100);       // Time for transmit signal On
      On();          // Simple way to call a signal on or off in program
      //delay(100);      // Time for signal Off for "Blink"
    }
  }
  //} else {
    //Serial.println("No Transmitter");
  //}
}

void transmitter(){
for (int i=0; i<10; i++) {

delay (7);

zero();           // preamble/ sync
zero();
zero();
zero();
zero();          // ) all 8 bits are the hard encoding A0 - A7
zero();
zero();
zero();
zero();
zero();          // contact on pin D8  (pin 10 on ic)
one();          // corresponds to pressing switch on pin D9 (pin11 on ic)
zero();          // contact on pin D10 (pin 12 on ic)
zero();          // contact on pin D11 (pin 13 on ic)
}                   // Loop for 10 send cycles to make sure it gets the message

}

void one ()
{
  digitalWrite(dataPin, HIGH);
  delayMicroseconds(400);
  digitalWrite(dataPin, LOW);
  delayMicroseconds(200);
  
}
void zero () {
  digitalWrite(dataPin, LOW); 
  delayMicroseconds(200);
  digitalWrite(dataPin, HIGH);
  delayMicroseconds(200);
  digitalWrite(dataPin, LOW); 
  delayMicroseconds(200);
  
}
void Off () {
  for (int i=0; i<10; i++){        // Cycles for 10 loops

  delay (7);
  
zero();                           // Off Sequence
zero();
zero();
zero();                           // You could do the same with the On sequence
zero();          
zero();
zero();
zero();
zero();
zero();          
zero();          
zero();          
zero();                         // Off sequence

  }
}

void On () {
  for (int i=0; i<10; i++){        // Cycles for 10 loops

  delay (7);
  
one();                           // Off Sequence
one();
one();
one();                           // You could do the same with the On sequence
one();          
one();
one();
one();
one();
one();          
one();          
one();          
one();                         // Off sequence

  }
}

