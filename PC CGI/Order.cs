using System;
namespace PC_CGI
{
    //TODO Добавить возможность сохранения заказа
    internal class Order
    {
        public void Set(string TableName, string value)
        {
            switch (TableName)
            {
                case "Колки": Kolk = value; break;
                case "Бридж": Bridge = value; break;
                case "Звукосниматель": SoundGet = value; break;
                case "Анкер": Anker = value; break;
                case "Вид_сборки": TypeBuild = value; break;
                case "Материал_корпуса": DecaMaterial = value; break;
                case "Струны": Strings = value; break;
                case "Покраска": Colouring = value; break;
                case "Материал_грифа": TypeGrif = value; break;
                case "Электронная_начинка": Electric = value; break;
                default: throw new Exception("Разработчик дурачок, ошибся");
            }
        }
        public string FIO = "";
        public string Phone = "";
        public string Description = "";
        public string ColoringImageLinck = "";
        public string Model3DLink = "";
        public string Kolk = "";
        public string SoundGet = "";
        public string Bridge = "";
        public string Anker = "";
        public string TypeBuild = "";
        public string TypeGrif = "";
        public string DecaMaterial = "";
        public string Strings = "";
        public string Colouring = "";
        public string Electric = "";
    }
}
