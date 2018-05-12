#include <SoftwareSerial.h>

SoftwareSerial esp_serial(4, 2); // RX | TX
String serial_buffer = "";

int speed_values[] = {80, 115, 150, 185, 220, 255};
int current_speed;
int turn_speed;

int echo = A4;
int trigger = A5;

int pwm_right = 5;
int pwm_left = 11;
int in1 = 6;
int in2 = 7;
int in3 = 8;
int in4 = 9;

int light_pin = 12;

void setup()
{
  Serial.begin(9600);
  esp_serial.begin(9600);

  current_speed = speed_values[5];
  turn_speed = speed_values[4];
  
  pinMode(in1, OUTPUT);
  pinMode(in2, OUTPUT);
  pinMode(in3, OUTPUT);
  pinMode(in4, OUTPUT);
  pinMode(pwm_right, OUTPUT);
  pinMode(pwm_left, OUTPUT);
  
  pinMode(trigger, OUTPUT); 
  pinMode(echo, INPUT);

  pinMode(light_pin, OUTPUT);
  digitalWrite(light_pin, LOW);
}

void loop()
{
  serial_buffer = "";
  
  while(esp_serial.available() == 0)
  { }

  if(esp_serial.available())
  {
    delay(10);
    serial_buffer.concat(esp_serial.readString());
  }

  Serial.println(serial_buffer);

  if(serial_buffer.indexOf("stop") > 0)
  {
    stop();
    Serial.println("Stop");
  }
  else if(serial_buffer.indexOf("forward") > 0)
  {
    moveForward();
    Serial.println("Forward");
  }
  else if(serial_buffer.indexOf("backward") > 0)
  {
    moveBackward();
    Serial.println("Backward");
  }
  else if(serial_buffer.indexOf("left") > 0)
  {
    turnLeft();
    Serial.println("Left");
  }
  else if(serial_buffer.indexOf("right") > 0)
  {
    turnRight();
    Serial.println("Right");
  }
  if(serial_buffer.indexOf("light_on") > 0)
  {
    switchLightOn();
    Serial.println("Light on");
  }
  if(serial_buffer.indexOf("light_off") > 0)
  {
    switchLightOff();
    Serial.println("Light off");
  }
  if(serial_buffer.indexOf("get_distance") > 0 && serial_buffer.indexOf("Referer") < 0)
  {
    sendDistance();
    Serial.println("Get distance");
  }
  if(serial_buffer.indexOf("set_speed") > 0)
  {
    updateSpeed();
    Serial.print("Set speed to: ");
    Serial.println(current_speed);
  }
}

void sendDistance()
{
  int index = serial_buffer.indexOf("get_distance");
  char connectionID = serial_buffer.charAt(index - 11);

  String send_command = "AT+CIPSEND=";
  send_command.concat(connectionID);
  send_command.concat(",3\r\n");

  String payload = "";
  long distance = measureDistance();
  if(distance >= 500 || distance <= 0)
  {
    payload = "err";
  }
  else if(distance >= 100)
  {
    payload.concat(distance);
  }
  else if(distance < 100)
  {
    payload.concat(0);
    if (distance >= 10)
    {
      payload.concat(distance);
    }
    else
    {
      payload.concat(0);
      payload.concat(distance);
    }
  }
  
  String close_command = "AT+CIPCLOSE=";
  close_command.concat(connectionID);
  close_command.concat("\r\n");

  esp_serial.print(send_command);
  delay(20);
  if(esp_serial.find("OK"))
  {
    esp_serial.print(payload);
    delay(20);
    if(esp_serial.find("OK"))
    {
      esp_serial.print(close_command);
    }
  }
}

long measureDistance()
{
  digitalWrite(trigger, LOW);
  delay(5);
  digitalWrite(trigger, HIGH);
  delay(10);
  digitalWrite(trigger, LOW);
  long echo_time = pulseIn(echo, HIGH);
  long distance = (echo_time/2) * 0.03432;
  return distance;
}

void updateSpeed()
{
  int index = serial_buffer.indexOf("set_speed=");
  current_speed = speed_values[serial_buffer.charAt(index + 10) - '0'];
}

void moveForward()
{ 
  analogWrite(pwm_right, current_speed);
  analogWrite(pwm_left, current_speed);
  digitalWrite(in1, HIGH);
  digitalWrite(in2, LOW);
  digitalWrite(in3, LOW);
  digitalWrite(in4, HIGH);
}

void moveBackward()
{
  analogWrite(pwm_right, current_speed);
  analogWrite(pwm_left, current_speed);
  digitalWrite(in1, LOW);
  digitalWrite(in2, HIGH);
  digitalWrite(in3, HIGH);
  digitalWrite(in4, LOW);
}

void turnLeft()
{
  analogWrite(pwm_right, turn_speed);
  analogWrite(pwm_left, turn_speed);
  digitalWrite(in1, HIGH);
  digitalWrite(in2, LOW);
  digitalWrite(in3, HIGH);
  digitalWrite(in4, LOW);
}

void turnRight()
{
  analogWrite(pwm_right, turn_speed);
  analogWrite(pwm_left, turn_speed);
  digitalWrite(in1, LOW);
  digitalWrite(in2, HIGH);
  digitalWrite(in3, LOW);
  digitalWrite(in4, HIGH);
}

void stop()
{
  analogWrite(pwm_right, HIGH);  
  analogWrite(pwm_left, HIGH); 
  digitalWrite(in1, LOW);      
  digitalWrite(in2, LOW);
  digitalWrite(in3, LOW);      
  digitalWrite(in4, LOW);
}

void switchLightOn()
{
  digitalWrite(light_pin, HIGH);
}

void switchLightOff()
{
  digitalWrite(light_pin, LOW);
}

