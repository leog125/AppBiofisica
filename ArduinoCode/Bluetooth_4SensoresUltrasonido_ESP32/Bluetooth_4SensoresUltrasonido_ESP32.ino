#include "BluetoothSerial.h"

#define SOUND_SPEED 0.034             // Velocidad del sonido en el aire ≈ 343 m/s
#define NUM_SENSORS 4                 // Número de sensores
#define TRIGGER_PINS { 2, 4, 6, 8 }   // Pines de trigger
#define ECHO_PINS { 3, 5, 7, 9 }      // Pines de echo
BluetoothSerial BT;                   // Objeto Bluetooth

int triggerPins[NUM_SENSORS] = TRIGGER_PINS;  // Copia los pines de trigger
int echoPins[NUM_SENSORS] = ECHO_PINS;        // Copia los pines de echo

void setup() {
  Serial.begin(115200);
  BT.begin("ESP32_LED_Control"); // Nombre de su dispositivo Bluetooth y en modo esclavo
  for (int i = 0; i < NUM_SENSORS; i++) {
    pinMode(triggerPins[i], OUTPUT);
    pinMode(echoPins[i], INPUT);
  }
}

void loop() {
  for (int i = 0; i < NUM_SENSORS; i++) {
    float distance = calculateDistance(i);

    if (BT.available())  // Compruebe si recibimos algo de Bluetooth
    {
      // Transmitir la distancia por Bluetooth
      BT.print("Sensor ");
      BT.print(i + 1);
      BT.print(": Distancia en cm: ");
      BT.println(distance);
    }
    
    // Transmitir la distancia por Serial
    Serial.print("Sensor ");
    Serial.print(i + 1);
    Serial.print(": Distancia en cm: ");
    Serial.println(distance);
  }
  delay(1000);  // Espera un segundo antes de realizar la siguiente medición
}

float calculateDistance(int sensorIndex) {
  long duration;
  float distance_cm;

  // Genera un pulso corto en el pin del trigger para iniciar la medición
  digitalWrite(triggerPins[sensorIndex], LOW);
  delayMicroseconds(2);
  digitalWrite(triggerPins[sensorIndex], HIGH);
  delayMicroseconds(10);
  digitalWrite(triggerPins[sensorIndex], LOW);

  // Lee la duración del pulso en el pin del echo
  duration = pulseIn(echoPins[sensorIndex], HIGH);
  // Calcula la distancia en centímetros
  distance_cm = duration * SOUND_SPEED / 2;  // Fórmula para convertir la duración del eco a cm
  return distance_cm;
}