using MmxCMS;
using MongoDB.Driver;
using System.Globalization;
using uShop.Models;

namespace uShop.Domain;

public class CSVtoDB
{
    public static double TryParseDouble(string src, double Default)
    {
        if (string.IsNullOrEmpty(src))
            return Default;

        if (double.TryParse(src.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double Result))
            return Result;

        return Default;
    }

    public void ExportCSVAsync()
    {

        string connectionString = "mongodb://master:159753@localhost/ushopbase?authSource=admin";
        string databaseName = "ushopbase";
        string CollectionName = "products";

        var client = new MongoClient(connectionString);
        var db = client.GetDatabase(databaseName);
        var collection = db.GetCollection<Product>(CollectionName);


        string[] lines = System.IO.File.ReadAllLines(@"D:\tovar.csv", System.Text.Encoding.UTF8);
        CSVFile csv = new(lines, ';', '"',
            "Код;Наименование;Иерархия;Артикул;Количество;Цена;Бренд;ИмяФайлаИзображения;Новинка;HAPPY_МОЛЛОстаток;ГлобусОстаток;ЛазурныйОстаток;ОранжевыйОстаток;ПассажОстаток;ТауОстаток;10 летняя батарея;Bluetooth;Барометр\\альтиметр;Браслет;Будильник;Включение,отключение звука кнопок;Водозащита;Грязеустойчивость;Дополнительно;Индикатор приливов и отливов;Индикатор уровня заряда аккумулятора;Компас;Материал корпуса;Мелодия;Мировое время;Отображение данных о Луне;Пол;Прием радиосигнала точного времени;Размер корпуса;Резерв хода;Сверх яркая подсветка;Связь со смартфоном;Скидка;Солнечная батарея;Стекло;Страна бренда;Страна производитель;Таймер;Таймер рыбалки;Термометр;Тип механизма;Ударопрочность;Устойчивость к воздействию магнитного поля;Форма корпуса;Функция поиска телефона;Функция секундомера;Хит продаж;Ход стрелки;Хронограф;Циферблат;Шагомер;ЦенаСоСкидкой",
            "Code1C;Name;Path;Article;TotalCount;Price;BrandName;ImgFileName;FlagNew;HM_Balance;GL_Balance;LZ_Balance;OR_Balance;PZ_Balance;TA_Balance;Battery10;Bluetooth;Barometer;Wristlet;Alarm;ButtonsSoundToggler;WaterProtection;DirtResistance;Extra;TideIndicator;BatteryLevelIndicator;Compass;CaseMaterial;Melody;WorldTime;MoonData;Gender;ExactTimeRadioSignal;CaseSize;PowerReserve;ExtraBrightBacklight;SmartphoneConnection;Discount;SolarBattery;Glass;BrandCountry;ProducingCountry;Taimer;FishingTimer;Thermometer;MechanismType;ImpactResistance;MagneticFieldResistance;CaseForm;PhoneSearchFunction;Stopwatch;FlagSaleLeader;ClockhandMovement;Chronograph;ClockFace;Pedometer;DiscountPrice");
        csv.Rewind();

        List<Product> Tovars = new();


        while (csv.Next())
        {
            // double.TryParse(csv["Discount"], out double Discount); - создана переменная, действие с ней, а потом присвоение внутри new Product значения переменной к полю (Discount = Discount)
            // сейчас универсальная функция на 10 строчке и ее вызов с обязательным параметром по умолчанию

            string CategoriesString = csv["Path"];
            string[] CatLev = CategoriesString.Split('/');
            string code1c = csv["Code1C"];
            //Console.WriteLine(Categories[1]);


            //В память загружается существующая в Mongo база
            //var existingTovar = Tovars.FirstOrDefault(x => x.Code1C == code1c);
            //if (existingTovar == null) {
            //    создание нового товара
            //}
            //else { 
            //    обновление существующего
            //}

            var tovar = new Product
            {
                Code1C = code1c,
                Name = csv["Name"],
                Path = csv["Path"],
                CatLev = CatLev.ToList(),
                Article = csv["Article"],
                BrandName = csv["BrandName"],
                ImgFileName = csv["ImgFileName"],
                Price = double.Parse(csv["Price"]),
                Discount = TryParseDouble(csv["Discount"], 0.0),
                DiscountPrice = double.Parse(csv["DiscountPrice"]),
                FlagNew = csv["FlagNew"] == "1",
                FlagSaleLeader = csv["FlagSaleLeader"] == "Да",
                TotalCount = Int32.Parse(csv["TotalCount"]),
                HM_Balance = Int32.Parse(csv["HM_Balance"]),
                GL_Balance = Int32.Parse(csv["GL_Balance"]),
                LZ_Balance = Int32.Parse(csv["LZ_Balance"]),
                OR_Balance = Int32.Parse(csv["OR_Balance"]),
                PZ_Balance = Int32.Parse(csv["PZ_Balance"]),
                TA_Balance = Int32.Parse(csv["TA_Balance"]),
                Battery10 = csv["Battery10"],
                Bluetooth = csv["Bluetooth"],
                Barometer = csv["Barometer"],
                Wristlet = csv["Wristlet"],
                Alarm = csv["Alarm"],
                ButtonsSoundToggler = csv["ButtonsSoundToggler"],
                WaterProtection = csv["WaterProtection"],
                DirtResistance = csv["DirtResistance"],
                Extra = csv["Extra"],
                TideIndicator = csv["TideIndicator"],
                BatteryLevelIndicator = csv["BatteryLevelIndicator"],
                Compass = csv["Compass"],
                CaseMaterial = csv["CaseMaterial"],
                Melody = csv["Melody"],
                WorldTime = csv["WorldTime"],
                MoonData = csv["MoonData"],
                Gender = csv["Gender"],
                ExactTimeRadioSignal = csv["ExactTimeRadioSignal"],
                CaseSize = csv["CaseSize"],
                PowerReserve = csv["PowerReserve"],
                ExtraBrightBacklight = csv["ExtraBrightBacklight"],
                SmartphoneConnection = csv["CasSmartphoneConnectioneSize"],
                SolarBattery = csv["SolarBattery"],
                Glass = csv["Glass"],
                BrandCountry = csv["BrandCountry"],
                ProducingCountry = csv["ProducingCountry"],
                Taimer = csv["Taimer"],
                FishingTimer = csv["FishingTimer"],
                Thermometer = csv["Thermometer"],
                MechanismType = csv["MechanismType"],
                ImpactResistance = csv["ImpactResistance"],
                MagneticFieldResistance = csv["MagneticFieldResistance"],
                CaseForm = csv["CaseForm"],
                PhoneSearchFunction = csv["PhoneSearchFunction"],
                Stopwatch = csv["Stopwatch"],
                ClockhandMovement = csv["ClockhandMovement"],
                Chronograph = csv["Chronograph"],
                ClockFace = csv["ClockFace"],
                Pedometer = csv["Pedometer"]
            };

            Console.WriteLine($"Код1C: {csv["Code1C"]}, Наименование: {csv["Name"]}, Артикул: {csv["Article"]}, Цена: {csv["Price"]}");

            Tovars.Add(tovar);

            //await collection.InsertOneAsync(tovar);

        }

        collection.InsertMany(Tovars);
    }

}

