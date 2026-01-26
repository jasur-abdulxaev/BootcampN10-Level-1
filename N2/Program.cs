#region
// Primitive types

bool hasNomey = true;

char dollarSIgn = '$';

byte age = 50;

sbyte normalRoomTemperature = 21;

short balance = -2000;

// Digit seperator
ushort distance = 65_000;

int countryPopulation = 2_000_000_000;

uint manufacturedItems = 4_000_000_000;

long planets = 9_000_000_000_000_000_000;

ulong planetsB = 18_000_000_000_000_000_000;

float weight = 3.14159265358979323846F;

double pi = 3.14159265358979323846D;

decimal piDecimal = 3.14159265358979323846m;

string firstName = "John";

Console.WriteLine(Math.PI);
Console.WriteLine(pi);
Console.WriteLine(piDecimal);
Console.WriteLine(firstName);

#endregion

#region Definition and Initialization

// Definition - E'lon qilish
byte ageB;
//Console.WriteLine(ageB);

//DO SOMETHING

//Initialization - Qiymat berish
ageB = 21;
#endregion

#region Read and Write

int speedA = 100;
int speedB;

// Write operation for speed B - speed B ga yozish operatsiyasi
speedB = speedA;

// Read operation for speed A - speed A esa o'qish operatsiyasi
speedA = speedB;

#endregion

#region Explicit and Implicity typing

//Implicit - bu yerda e'lon qilinishida farqi implicitda o'zi aniqlaydi
var lastName = "John";

// Type doesn't change
//lastName = true;

//Initialization is must
var ageX = 12;
//var fullName;
//fullName = firstName + lastName;

// Explicit
int ageZ = 10;

#endregion

#region Literals or Const value - Literallar bular code ichida elon qilinadigan o'zgaruvchilar ya'ni konstantalar

var boolValue = false;
var charValue = '@';
var byteValue = (byte)10;
var sbayteValue = (sbyte)10;
var intValue = 10;
var uintValue = 10U;
var shortValue = (short)10;
var ushortValue = (ushort)10;
var longValue = 10L;
var ulongValue = 10UL;
var floatValue = 10F;
var doubleValue = 10D;
var decimalValue = 10M;
var stringValue = "Bob";

Console.ForegroundColor = ConsoleColor.Green;

//Default value
int price = default;
var priceB = default(int);
Console.WriteLine($"Price: {price}");
bool defaultValue = true;
defaultValue = default;

string defaultStringValue = default;
string defaultStringValueB = string.Empty;

Console.WriteLine(defaultValue);

#endregion

#region Primitive and Complex types
// Primitive 
var productName = "Headphones";

// Complex
DateTime now = DateTime.Now;
Console.WriteLine(now);

#endregion

#region Value and Reference types - Xotirani(RAM) qayeridan joy egallashiga qarab

//Value types
bool isWhite = false;

// Reference type
var address = "Alisher NAvoiy ko'chasi, 23";

#endregion

#region Static and Dinamic

// Static 
var modelNumber = "34567890";

//Dynamic

#endregion

var defaultStringValueX = String.Empty;
Console.WriteLine(defaultStringValueX);
