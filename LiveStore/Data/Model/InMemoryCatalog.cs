using LiveStore.Data.Interfaces;

namespace LiveStore.Data.Model;

public class InMemoryCatalog : ICatalog
{
    private readonly IClock _currentDate;


    private readonly IReadOnlyCollection<Product> _products = new Product[]
    {
        new(1, 1, "Смартфон Apple iPhone 13 256GB", 85000m, "https://img.mvideo.ru/Big/30059042bb.jpg",
            "iPhone 13. Самая совершенная система двух камер на iPhone. Режим «Киноэффект» делает из видео настоящее кино."),
        new(2, 1, "Наушники Apple AirPods Pro", 18865m, "https://img.mvideo.ru/Big/50131384bb.jpg",
            "Apple AirPods Pro with Wireless Case – первые внутриканальные беспроводные наушники американского бренда."),
        new(3, 2, "Телевизор Samsung", 66707m, "https://img.mvideo.ru/Big/10026701bb.jpg",
            "телевизор Samsung обладает большим 43-дюймовым экраном с разрешением 3840х2160 пикселей и поддержкой HDR."),
        new(4, 4, "Монитор игровой AOPEN", 19450m, "https://img.mvideo.ru/Big/30050968bb.jpg",
            "Вместе с монитором AOpen 27HC5RPbiipx ты не растеряешься на поле боя, всегда сможешь уверенно командовать армией и замечать противников периферическим зрением."),
        new(5, 3, "Утюг Philips GC4560/07", 66667m, "https://img.mvideo.ru/Big/20056899bb.jpg",
            "Philips GC4560/07 – лёгкий и удобный утюг из серии Azur. Мощность 2 600 Вт обеспечивает быстрый нагрев и превосходный результат."),
        new(6, 1, "Ноутбук Acer Swift 1", 27831m, "https://img.mvideo.ru/Big/30057259bb.jpg",
            "Ультрабук Acer Swift 1 SF114-34-C857 ––компактный и мощный инструмент для эффективного решения большинства повседневных задач."),
        new(7, 1, "Смартфон Samsung Galaxy Z", 159999m, "https://img.mvideo.ru/Big/30058454bb.jpg",
            "Samsung Galaxy Z Fold 3 – смартфон с экраном 6,2 дюйма, а в раскрытом виде – полноценный планшет."),
        new(8, 2, "Телевизор LG 55UP75006LF", 47999m, "https://img.mvideo.ru/Big/10026626bb.jpg",
            "Телевизор LG 55UP75006LF покажет изображение, которое заставит вас погрузиться в виртуальный мир. "),
        new(9, 4, "Консоль Sony PlayStation 5", 49990m, "https://img.mvideo.ru/Big/40073270bb.jpg",
            "Революция уже на подходе – PlayStation 5 готова раскрыть возможности некстгена благодаря впечатляющим характеристикам, принципиально отличающимся от консолей прошлого поколения."),
        new(10, 3, "Кофемашина DeLonghi", 56999m, "https://img.mvideo.ru/Pdb/20031629b.jpg",
            "Компактная кофемашина De Longhi ETAM 29.660.SB найдёт место даже на небольшой кухне и впишется в интерьер офиса.")
    };

    public InMemoryCatalog(IClock currentDate)
    {
        _currentDate = currentDate;
    }

    public IReadOnlyCollection<Product> GetProducts()
    {
        var date = _currentDate.GetCurrentDate();
        if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            return _products
                .Select(it => it with {Price = it.Price * 1.5m})
                .ToList();
        return _products;
    }
}