using Aula7_LetsCode;

var quadrado = new Quadrado();
quadrado.Lado = 5;
Console.WriteLine(quadrado.CalcularArea());

var circulo = new Circulo();
circulo.Raio = 3;
Console.WriteLine(circulo.CalcularArea());

var retangulo = new Retangulo();
retangulo.Base = 8;
retangulo.Altura = 11;
Console.WriteLine(retangulo.CalcularArea());

var triangulo = new Triangulo();
triangulo.Base = 9;
triangulo.Altura = 13;
Console.WriteLine(triangulo.CalcularArea());