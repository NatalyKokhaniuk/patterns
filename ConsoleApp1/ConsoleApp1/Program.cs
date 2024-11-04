using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** 
 ////
namespace ConsoleApp1
{
    internal class Program
    {
        public class Logger
        {
            private static Logger _instance;

            private Logger() { }

            public static Logger GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }

            public void Log(string message)
            {
                Console.WriteLine($"Log: {message}");
            }
        }

        public class AdvertisementManager
        {
            private static AdvertisementManager _instance;
            private List<string> advertisements;

            private AdvertisementManager()
            {
                advertisements = new List<string>();
            }

            public static AdvertisementManager GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new AdvertisementManager();
                }
                return _instance;
            }

            public void AddAdvertisement(string ad)
            {
                advertisements.Add(ad);
                Logger.GetInstance().Log($"Advertisement added: {ad}");
            }

            public void ShowAdvertisements()
            {
                Console.WriteLine("Current Advertisements:");
                foreach (var ad in advertisements)
                {
                    Console.WriteLine(ad);
                }
            }
        }
        static void Main(string[] args)
        {
            AdvertisementManager manager = AdvertisementManager.GetInstance();

            manager.AddAdvertisement("Ad for Product A");
            manager.AddAdvertisement("Ad for Product B");

            manager.ShowAdvertisements();

            Console.ReadLine();
        }

    }
}

/*namespace ConsoleApp1
{
    internal class Program
    {
        public abstract class Advertisement
        {
            public string Title { get; set; }
            public abstract Advertisement Clone();
        }

        public class ConcreteAdvertisement : Advertisement
        {
            public ConcreteAdvertisement(string title)
            {
                Title = title;
            }

            public override Advertisement Clone()
            {
                return new ConcreteAdvertisement(Title);
            }
        }

        public class AdvertisementManager
        {
            private List<Advertisement> advertisements;

            public AdvertisementManager()
            {
                advertisements = new List<Advertisement>();
            }

            public void AddAdvertisement(Advertisement ad)
            {
                advertisements.Add(ad.Clone());
            }

            public void ShowAdvertisements()
            {
                Console.WriteLine("Current Advertisements:");
                foreach (var ad in advertisements)
                {
                    Console.WriteLine(ad.Title);
                }
            }
        }
        static void Main(string[] args)
        {
            AdvertisementManager manager = new AdvertisementManager();

            ConcreteAdvertisement prototypeAd = new ConcreteAdvertisement("Ad for Product A");
            ConcreteAdvertisement prototypeAd2 = new ConcreteAdvertisement("Ad for Product B");
            ConcreteAdvertisement prototypeAd3 = new ConcreteAdvertisement("Ad for Product C");

            manager.AddAdvertisement(prototypeAd);
            manager.AddAdvertisement(prototypeAd2);
            manager.AddAdvertisement(prototypeAd2);
            manager.AddAdvertisement(prototypeAd3);
            manager.AddAdvertisement(prototypeAd);

            manager.ShowAdvertisements();

            Console.ReadLine();
        }

    }
}/

//namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        string GetDetails();
    }

    public class ProductAdvertisement : IAdvertisement
    {
        public string Title { get; set; }

        public ProductAdvertisement(string title)
        {
            Title = title;
        }

        public string GetDetails()
        {
            return $"Product Advertisement: {Title}";
        }
    }

    public class ServiceAdvertisement : IAdvertisement
    {
        public string Title { get; set; }

        public ServiceAdvertisement(string title)
        {
            Title = title;
        }

        public string GetDetails()
        {
            return $"Service Advertisement: {Title}";
        }
    }
    public abstract class AdvertisementFactory
    {
        public abstract IAdvertisement CreateAdvertisement();
    }

    public class ProductAdvertisementFactory : AdvertisementFactory
    {
        private string title;

        public ProductAdvertisementFactory(string title)
        {
            this.title = title;
        }

        public override IAdvertisement CreateAdvertisement()
        {
            return new ProductAdvertisement(title);
        }
    }

    public class ServiceAdvertisementFactory : AdvertisementFactory
    {
        private string title;

        public ServiceAdvertisementFactory(string title)
        {
            this.title = title;
        }

        public override IAdvertisement CreateAdvertisement()
        {
            return new ServiceAdvertisement(title);
        }
    static void Main(string[] args)
        {
        AdvertisementFactory productFactory = new ProductAdvertisementFactory("Product A");
        IAdvertisement productAd = productFactory.CreateAdvertisement();
        Console.WriteLine(productAd.GetDetails());

        AdvertisementFactory serviceFactory = new ServiceAdvertisementFactory("Service B");
        IAdvertisement serviceAd = serviceFactory.CreateAdvertisement();
        Console.WriteLine(serviceAd.GetDetails());

        Console.ReadLine();
    }

    }
}

/namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        string GetDetails();
    }

    public class ShortAdvertisement : IAdvertisement
    {
        public string Title { get; set; }

        public ShortAdvertisement(string title)
        {
            Title = title;
        }

        public string GetDetails()
        {
            return $"Short Advertisement: {Title}";
        }
    }

    public class LongAdvertisement : IAdvertisement
    {
        public string Content { get; set; }

        public LongAdvertisement(string content)
        {
            Content = content;
        }

        public string GetDetails()
        {
            return $"Long Advertisement: {Content}";
        }
    }

    public interface IAdvertisementFactory
    {
        IAdvertisement CreateAdvertisement();
    }

    public class ShortAdvertisementFactory : IAdvertisementFactory
    {
        private string title;

        public ShortAdvertisementFactory(string title)
        {
            this.title = title;
        }

        public IAdvertisement CreateAdvertisement()
        {
            return new ShortAdvertisement(title);
        }
    }

    public class LongAdvertisementFactory : IAdvertisementFactory
    {
        private string content;

        public LongAdvertisementFactory(string content)
        {
            this.content = content;
        }

        public IAdvertisement CreateAdvertisement()
        {
            return new LongAdvertisement(content);
        }
        static void Main(string[] args)
        {
            IAdvertisementFactory bannerFactory = new ShortAdvertisementFactory("Big Sale! Notebooks!");
            IAdvertisement bannerAd = bannerFactory.CreateAdvertisement();
            Console.WriteLine(bannerAd.GetDetails());

            IAdvertisementFactory textFactory = new LongAdvertisementFactory("Limited Time Offer! New smartphones!");
            IAdvertisement textAd = textFactory.CreateAdvertisement();
            Console.WriteLine(textAd.GetDetails());

            Console.ReadLine();
        }

    }
}
namespace ConsoleApp1
{
    public class Advertisement
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Duration { get; set; }
        public string Format { get; set; }
    }

    public interface IAdvertisementBuilder
    {
        void SetTitle(string title);
        void SetContent(string content);
        void SetDuration(string duration);
        void SetFormat(string format);
        Advertisement Build();
    }

    public class ConcreteAdvertisementBuilder : IAdvertisementBuilder
    {
        private Advertisement advertisement;

        public ConcreteAdvertisementBuilder()
        {
            advertisement = new Advertisement();
        }

        public void SetTitle(string title) { advertisement.Title = title; }
        public void SetContent(string content) { advertisement.Content = content; }
        public void SetDuration(string duration) { advertisement.Duration = duration; }
        public void SetFormat(string format) { advertisement.Format = format; }
        public Advertisement Build() { return advertisement; }
    }

    public class AdvertisementDirector
    {
        private IAdvertisementBuilder builder;

        public AdvertisementDirector(IAdvertisementBuilder builder)
        {
            this.builder = builder;
        }

        public Advertisement ConstructAdvertisement(string title, string content, string duration, string format)
        {
            builder.SetTitle(title);
            builder.SetContent(content);
            builder.SetDuration(duration);
            builder.SetFormat(format);
            return builder.Build();
        }
        static void Main(string[] args)
        {
            IAdvertisementBuilder builder = new ConcreteAdvertisementBuilder();
            AdvertisementDirector director = new AdvertisementDirector(builder);

            Advertisement ad = director.ConstructAdvertisement("Big Sale", "Get 50% off!", "30s", "Video");
            Console.WriteLine($"Advertisement Title: {ad.Title}, Content: {ad.Content}, Duration: {ad.Duration}, Format: {ad.Format}");

            Console.ReadLine();
        }

    }
}
namespace ConsoleApp1
{
    public class Advertisement
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public void Display()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }

    public class ObjectPool<T> where T : new()
    {
        private readonly Stack<T> _available = new Stack<T>();
        private readonly int _maxSize;

        public ObjectPool(int initialSize, int maxSize)
        {
            _maxSize = maxSize;
            for (int i = 0; i < initialSize; i++)
            {
                _available.Push(new T());
            }
        }

        public T Acquire()
        {
            if (_available.Count > 0)
            {
                return _available.Pop();
            }
            return new T(); 
        }

        public void Release(T item)
        {
            if (_available.Count < _maxSize)
            {
                _available.Push(item);
            }
        }
    }

    public class AdvertisementPool : ObjectPool<Advertisement>
    {
        public AdvertisementPool(int initialSize, int maxSize) : base(initialSize, maxSize) { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var adPool = new AdvertisementPool(2, 5);
            var ad1 = adPool.Acquire();
            ad1.Title = "Ad 1";
            ad1.Content = "Content for Ad 1";
            ad1.Display();

            adPool.Release(ad1);

            var ad2 = adPool.Acquire();
            ad2.Title = "Ad 2";
            ad2.Content = "Content for Ad 2";
            ad2.Display();

            Console.ReadLine();
        }
    }
}

namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        void Show();
    }

    public class TraditionalAdvertisement : IAdvertisement
    {
        public void Show() { Console.WriteLine("Showing long advertisement."); }
    }

    public class ShortAdvertisement
    {
        public void Display() { Console.WriteLine("Displaying short advertisement."); }
    }

    public class ShortAdvertisementAdapter : IAdvertisement
    {
        private ShortAdvertisement _ShortAdvertisement;

        public ShortAdvertisementAdapter(ShortAdvertisement ShortAdvertisement)
        {
            _ShortAdvertisement = ShortAdvertisement;
        }

        public void Show()
        {
            _ShortAdvertisement.Display();
        }
    }

    public class AdvertisementManager
    {
        private List<IAdvertisement> _advertisements = new List<IAdvertisement>();

        public void AddAdvertisement(IAdvertisement ad)
        {
            _advertisements.Add(ad);
        }

        public void ShowAllAdvertisements()
        {
            foreach (var ad in _advertisements)
            {
                ad.Show();
            }
        }
        static void Main(string[] args)
        {
        var manager = new AdvertisementManager();

        var traditionalAd = new TraditionalAdvertisement();
        manager.AddAdvertisement(traditionalAd);

        var ShortAd = new ShortAdvertisementAdapter(new ShortAdvertisement());
        manager.AddAdvertisement(ShortAd);

        manager.ShowAllAdvertisements();
        Console.ReadLine();
    }

    }
}

namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        void Show();
    }

    public class SimpleAdvertisement : IAdvertisement
    {
        public void Show()
        {
            Console.WriteLine("This is a simple advertisement.");
        }
    }

    public abstract class AdType
    {
        protected IAdvertisement _advertisement;

        protected AdType(IAdvertisement advertisement)
        {
            _advertisement = advertisement;
        }

        public abstract void ShowAd();
    }

    public class LongAdvertisement : AdType
    {
        public LongAdvertisement(IAdvertisement advertisement) : base(advertisement) { }

        public override void ShowAd()
        {
            Console.WriteLine("Long Advertisement:");
            _advertisement.Show();
        }
    }

    public class ShortAdvertisement : AdType
    {
        public ShortAdvertisement(IAdvertisement advertisement) : base(advertisement) { }

        public override void ShowAd()
        {
            Console.WriteLine("Short Advertisement:");
            _advertisement.Show();
        }
        static void Main(string[] args)
        {

        IAdvertisement simpleAd = new SimpleAdvertisement();

        AdType LongAd = new LongAdvertisement(simpleAd);
            LongAd.ShowAd();

        AdType ShortAd = new ShortAdvertisement(simpleAd);
            ShortAd.ShowAd();
        Console.ReadLine();
        }

    }
}/**/


/*/
//– Composite Pattern (Деревовидна структура)
namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        void Show();
    }

    public class AnAdvertisement : IAdvertisement
    {
        public void Show()
        {
            Console.WriteLine("This is a an advertisement.");
        }
    }

    public abstract class AdType
    {
        protected IAdvertisement _advertisement;

        protected AdType(IAdvertisement advertisement)
        {
            _advertisement = advertisement;
        }

        public abstract void ShowAd();
    }

    public class LongAdvertisement : AdType
    {
        public LongAdvertisement(IAdvertisement advertisement) : base(advertisement) { }

        public override void ShowAd()
        {
            Console.WriteLine("Long Advertisement:");
            _advertisement.Show();
        }
    }

    public class ShortAdvertisement : AdType
    {
        public ShortAdvertisement(IAdvertisement advertisement) : base(advertisement) { }

        public override void ShowAd()
        {
            Console.WriteLine("Short Advertisement:");
            _advertisement.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAdvertisement Ad = new AnAdvertisement();

            AdType longAd = new LongAdvertisement(Ad);
            longAd.ShowAd();

            AdType shortAd = new ShortAdvertisement(Ad);
            shortAd.ShowAd();

            Console.ReadLine();
        }
    }
}


/**/
// Decorator Pattern (Декоратор)
/*namespace ConsoleApp1 
{
    public interface IAdvertisement
    {
        void Show();
    }

    public class BasicAdvertisement : IAdvertisement
    {
        public void Show()
        {
            Console.WriteLine("This is a basic advertisement.");
        }
    }

    public abstract class AdvertisementDecorator : IAdvertisement
    {
        protected IAdvertisement _advertisement;

        public AdvertisementDecorator(IAdvertisement advertisement)
        {
            _advertisement = advertisement;
        }

        public virtual void Show()
        {
            _advertisement.Show();
        }
    }

    public class MusicDecorator : AdvertisementDecorator
    {
        public MusicDecorator(IAdvertisement advertisement) : base(advertisement) { }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("This advertisement is with music.");
        }
    }

    public class SizeDecorator : AdvertisementDecorator
    {
        public SizeDecorator(IAdvertisement advertisement) : base(advertisement) { }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("This advertisement is long.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAdvertisement basicAd = new BasicAdvertisement();

            IAdvertisement MusicAd = new MusicDecorator(basicAd);
            MusicAd.Show();

            IAdvertisement sizedAd = new SizeDecorator(basicAd);
            sizedAd.Show();

            IAdvertisement complexAd = new SizeDecorator(new MusicDecorator(basicAd));
            complexAd.Show();

            Console.ReadLine();
        }
    }
}/**/

/**
// Facade Pattern (Фасад)
namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        void Show();
    }

    public class BasicAdvertisement : IAdvertisement
    {
        public void Show()
        {
            Console.WriteLine("This is a basic advertisement.");
        }
    }

    public class AdvertisementDatabase
    {
        private List<IAdvertisement> _advertisements = new List<IAdvertisement>();

        public void Save(IAdvertisement advertisement)
        {
            _advertisements.Add(advertisement);
            Console.WriteLine("Advertisement saved.");
        }

        public List<IAdvertisement> RetrieveAll()
        {
            return _advertisements;
        }
    }

    public class AdScheduler
    {
        public void Schedule(IAdvertisement advertisement, DateTime time)
        {
            Console.WriteLine($"Advertisement scheduled at {time}");
        }
    }

    public class AdvertisementManager
    {
        private AdvertisementDatabase _database = new AdvertisementDatabase();
        private AdScheduler _scheduler = new AdScheduler();

        public void AddAdvertisement(IAdvertisement advertisement)
        {
            _database.Save(advertisement);
        }

        public void ShowAdvertisements()
        {
            var ads = _database.RetrieveAll();
            foreach (var ad in ads)
            {
                ad.Show();
            }
        }

        public void ScheduleAdvertisement(IAdvertisement advertisement, DateTime time)
        {
            _scheduler.Schedule(advertisement, time);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AdvertisementManager manager = new AdvertisementManager();
            IAdvertisement ad1 = new BasicAdvertisement();

            manager.AddAdvertisement(ad1);
            manager.ShowAdvertisements();
            manager.ScheduleAdvertisement(ad1, DateTime.Now.AddHours(1));

            Console.ReadLine();
        }
    }
}
/**/

/*/
// – Flyweight Pattern (Пристосуванець)
namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        void Show();
    }

    public class ConcreteAdvertisement : IAdvertisement
    {
        public string Content { get; private set; }

        public ConcreteAdvertisement(string content)
        {
            Content = content;
        }

        public void Show()
        {
            Console.WriteLine($"Advertisement Content: {Content}");
        }
    }

    public class AdvertisementFactory
    {
        private Dictionary<string, ConcreteAdvertisement> _advertisements = new Dictionary<string, ConcreteAdvertisement>();

        public ConcreteAdvertisement GetAdvertisement(string content)
        {
            if (!_advertisements.ContainsKey(content))
            {
                _advertisements[content] = new ConcreteAdvertisement(content);
                Console.WriteLine("Creating new advertisement.");
            }
            return _advertisements[content];
        }

        public void Clear()
        {
            _advertisements.Clear();
        }
    }

    public class AdvertisementManager
    {
        private AdvertisementFactory _factory = new AdvertisementFactory();

        public void AddAdvertisement(string content)
        {
            var ad = _factory.GetAdvertisement(content);
            ad.Show();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AdvertisementManager manager = new AdvertisementManager();
            manager.AddAdvertisement("Buy One Get One Free!");
            manager.AddAdvertisement("Limited Time Offer!");
            manager.AddAdvertisement("Buy One Get One Free!"); // Reuses existing advertisement

            Console.ReadLine();
        }
    }
}/**/

/*/ 
// – Proxy Pattern (Заступник)
namespace ConsoleApp1
{
    public interface IAdvertisement
    {
        void Show();
    }

    public class RealAdvertisement : IAdvertisement
    {
        public string Content { get; private set; }

        public RealAdvertisement(string content)
        {
            Content = content;
        }

        public void Show()
        {
            Console.WriteLine($"Advertisement Content: {Content}");
        }
    }

    public class AdvertisementProxy : IAdvertisement
    {
        private RealAdvertisement _realAdvertisement;
        private string _content;

        public AdvertisementProxy(string content)
        {
            _content = content;
        }

        public void Show()
        {
            if (_realAdvertisement == null)
            {
                _realAdvertisement = new RealAdvertisement(_content);
            }
            _realAdvertisement.Show();
        }
    }

    public class AdvertisementManager
    {
        private List<IAdvertisement> _advertisements = new List<IAdvertisement>();

        public void AddAdvertisement(string content)
        {
            _advertisements.Add(new AdvertisementProxy(content));
        }

        public void ShowAdvertisement(string content)
        {
            foreach (var ad in _advertisements)
            {
                ad.Show();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AdvertisementManager manager = new AdvertisementManager();
            manager.AddAdvertisement("Buy One Get One Free!");
            manager.AddAdvertisement("Limited Time Offer!");

            manager.ShowAdvertisement("Buy One Get One Free!");

            Console.ReadLine();
        }
    }
}
/**

//
// ChainofResponsibilityPattern (Ланцюжок відповідальностей)
namespace ConsoleApp1
{
    public class AdvertisementRequest
    {
        public string Content { get; }
        public int Priority { get; }

        public AdvertisementRequest(string content, int priority)
        {
            Content = content;
            Priority = priority;
        }
    }

    public interface IChannel
    {
        void SetNext(IChannel channel);
        void HandleRequest(AdvertisementRequest request);
    }

    public abstract class AbstractChannel : IChannel
    {
        protected IChannel _nextChannel;

        public void SetNext(IChannel channel)
        {
            _nextChannel = channel;
        }

        public virtual void HandleRequest(AdvertisementRequest request)
        {
            _nextChannel?.HandleRequest(request);
        }
    }

    public class ConcreteChannelA : AbstractChannel
    {
        public override void HandleRequest(AdvertisementRequest request)
        {
            if (request.Priority == 1)
            {
                Console.WriteLine($"{request.Content} is now on Channel A");
            }
            else
            {
                base.HandleRequest(request);
            }
        }
    }

    public class ConcreteChannelB : AbstractChannel
    {
        public override void HandleRequest(AdvertisementRequest request)
        {
            if (request.Priority == 2)
            {
                Console.WriteLine($"{request.Content} is now on Channel B");
            }
            else
            {
                base.HandleRequest(request);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var channelA = new ConcreteChannelA();
            var channelB = new ConcreteChannelB();
            channelA.SetNext(channelB);

            var request1 = new AdvertisementRequest("Ad 1", 1);
            var request2 = new AdvertisementRequest("Ad 2", 2);
            var request3 = new AdvertisementRequest("Ad 3", 3);

            channelA.HandleRequest(request1);
            channelA.HandleRequest(request2);
            channelA.HandleRequest(request3);

            Console.ReadLine();
        }
    }
}/**/

/* 
// Command Pattern (Команда)
namespace ConsoleApp1
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class Advertisement
    {
        public string Content { get; }

        public Advertisement(string content)
        {
            Content = content;
        }
    }

    public class AddAdvertisementCommand : ICommand
    {
        private AdvertisementManager _advertisementManager;
        private Advertisement _advertisement;

        public AddAdvertisementCommand(AdvertisementManager manager, Advertisement advertisement)
        {
            _advertisementManager = manager;
            _advertisement = advertisement;
        }

        public void Execute()
        {
            _advertisementManager.AddAdvertisement(_advertisement);
        }

        public void Undo()
        {
            _advertisementManager.RemoveAdvertisement(_advertisement.Content);
        }
    }

    public class RemoveAdvertisementCommand : ICommand
    {
        private AdvertisementManager _advertisementManager;
        private string _content;

        public RemoveAdvertisementCommand(AdvertisementManager manager, string content)
        {
            _advertisementManager = manager;
            _content = content;
        }

        public void Execute()
        {
            _advertisementManager.RemoveAdvertisement(_content);
        }

        public void Undo()
        {
            _advertisementManager.AddAdvertisement(new Advertisement(_content));
        }
    }

    public class AdvertisementManager
    {
        private List<Advertisement> _advertisements = new List<Advertisement>();

        public void AddAdvertisement(Advertisement advertisement)
        {
            _advertisements.Add(advertisement);
            Console.WriteLine($"Added: {advertisement.Content}");
        }

        public void RemoveAdvertisement(string content)
        {
            var adToRemove = _advertisements.Find(ad => ad.Content == content);
            if (adToRemove != null)
            {
                _advertisements.Remove(adToRemove);
                Console.WriteLine($"Removed: {content}");
            }
        }

        public void InvokeCommand(ICommand command)
        {
            command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var manager = new AdvertisementManager();

            var ad1 = new Advertisement("Ad 1");
            var ad2 = new Advertisement("Ad 2");
            var ad3 = new Advertisement("Ad 3");
            var addCommand = new AddAdvertisementCommand(manager, ad1);
            var addCommand2 = new AddAdvertisementCommand(manager, ad2);
            var addCommand3 = new AddAdvertisementCommand(manager, ad3);
            var removeCommand = new RemoveAdvertisementCommand(manager, "Ad 1");
            var removeCommand2 = new RemoveAdvertisementCommand(manager, "Ad 2");
            var removeCommand3 = new RemoveAdvertisementCommand(manager, "Ad 3");

            manager.InvokeCommand(addCommand);
            manager.InvokeCommand(removeCommand);
            manager.InvokeCommand(addCommand2);
            manager.InvokeCommand(addCommand3);
            manager.InvokeCommand(removeCommand3);
            manager.InvokeCommand(removeCommand2);

            Console.ReadLine();
        }
    }
}/**/


/*/
// – Iterator Pattern (Ітератор)
namespace ConsoleApp1
{
    public class Advertisement
    {
        public string Content { get; }

        public Advertisement(string content)
        {
            Content = content;
        }
    }

    public interface IIterator
    {
        Advertisement Current { get; }
        bool MoveNext();
        void Reset();
    }

    public class AdvertisementIterator : IIterator
    {
        private readonly AdvertisementCollection _collection;
        private int _currentIndex = -1;

        public AdvertisementIterator(AdvertisementCollection collection)
        {
            _collection = collection;
        }

        public Advertisement Current => _collection[_currentIndex];

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _collection.Count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }

    public interface IAggregate
    {
        IIterator CreateIterator();
    }

    public class AdvertisementCollection : IAggregate
    {
        private readonly List<Advertisement> _advertisements = new List<Advertisement>();

        public void Add(Advertisement ad)
        {
            _advertisements.Add(ad);
        }

        public Advertisement this[int index] => _advertisements[index];

        public int Count => _advertisements.Count;

        public IIterator CreateIterator()
        {
            return new AdvertisementIterator(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var collection = new AdvertisementCollection();
            collection.Add(new Advertisement("Ad 1"));
            collection.Add(new Advertisement("Ad 2"));
            collection.Add(new Advertisement("Ad 3"));
            collection.Add(new Advertisement("Ad 3"));
            collection.Add(new Advertisement("Ad 2"));
            collection.Add(new Advertisement("Ad 1"));

            var iterator = collection.CreateIterator();
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.Content);
            }

            Console.ReadLine();
        }
    }
}/**/
/**
// Mediator Pattern (Посередник)
namespace ConsoleApp1
{
        public class Advertisement
        {
            public string Content { get; set; }
            public int Duration { get; set; }
        }

        public interface IMediator
        {
            void RegisterDepartment(Department department);
            void Send(string message, Department sender);
        }

        public class AdvertisementMediator : IMediator
        {
            private List<Department> _departments = new List<Department>();

            public void RegisterDepartment(Department department)
            {
                _departments.Add(department);
            }

            public void Send(string message, Department sender)
            {
                foreach (var dept in _departments)
                {
                    if (dept != sender)
                        dept.Receive(message);
                }
            }
        }

        public abstract class Department
        {
            protected IMediator _mediator;

            public Department(IMediator mediator)
            {
                _mediator = mediator;
            }

            public abstract void Receive(string message);
        }

        public class ScheduleDepartment : Department
        {
            public ScheduleDepartment(IMediator mediator) : base(mediator) { }

            public void PlanAd(Advertisement ad)
            {
                _mediator.Send($"Planned ad with content: {ad.Content}", this);
            }

            public override void Receive(string message)
            {
                Console.WriteLine($"Schedule Department received: {message}");
            }
        }
        public class FinanceDepartment : Department
        {
            public FinanceDepartment(IMediator mediator) : base(mediator) { }

            public void ApproveAd(Advertisement ad)
            {
                _mediator.Send($"Approved ad with content: {ad.Content}", this);
            }

            public override void Receive(string message)
            {
                Console.WriteLine($"Finance Department received: {message}");
            }
        }

    class Program
    {
        static void Main()
        {
            AdvertisementMediator mediator = new AdvertisementMediator();

            var finance = new FinanceDepartment(mediator);
            var schedule = new ScheduleDepartment(mediator);

            mediator.RegisterDepartment(finance);
            mediator.RegisterDepartment(schedule);

            var ad = new Advertisement { Content = "New Ad", Duration = 30 };
            var ad2 = new Advertisement { Content = "Ad 2", Duration = 25 };

            schedule.PlanAd(ad);
            finance.ApproveAd(ad);
            schedule.PlanAd(ad2);
            finance.ApproveAd(ad2);

            Console.ReadLine();
        }
    }
}/**/

//Memento Pattern (Хранитель)
/*/namespace ConsoleApp1
{
    class Program
    {
        public class Advertisement
        {
            public string Content { get; set; }
            public DateTime StartTime { get; set; }
            public int Duration { get; set; }
        }

        public class ScheduleMemento
        {
            public List<Advertisement> State { get; private set; }

            public ScheduleMemento(List<Advertisement> state)
            {
                State = new List<Advertisement>(state);
            }
        }

        public class Schedule
        {
            private List<Advertisement> _advertisements = new List<Advertisement>();

            public void AddAdvertisement(Advertisement ad)
            {
                _advertisements.Add(ad);
            }

            public void RemoveAdvertisement(Advertisement ad)
            {
                _advertisements.Remove(ad);
            }

            public ScheduleMemento Save()
            {
                return new ScheduleMemento(_advertisements);
            }

            public void Restore(ScheduleMemento memento)
            {
                _advertisements = new List<Advertisement>(memento.State);
            }

            public List<Advertisement> GetAdvertisements()
            {
                return _advertisements;
            }
        }

        public class ScheduleCaretaker
        {
            private Stack<ScheduleMemento> _history = new Stack<ScheduleMemento>();

            public void SaveState(Schedule schedule)
            {
                _history.Push(schedule.Save());
            }

            public void Undo(Schedule schedule)
            {
                if (_history.Count > 0)
                    schedule.Restore(_history.Pop());
            }
        }

        static void Main()
        {
            var schedule = new Schedule();
            var caretaker = new ScheduleCaretaker();

            var ad1 = new Advertisement { Content = "Ad 1", StartTime = DateTime.Now, Duration = 30 };
            var ad2 = new Advertisement { Content = "Ad 2", StartTime = DateTime.Now.AddMinutes(1), Duration = 45 };

            schedule.AddAdvertisement(ad1);
            caretaker.SaveState(schedule);

            schedule.AddAdvertisement(ad2);
            caretaker.SaveState(schedule);

            schedule.RemoveAdvertisement(ad1);

            caretaker.Undo(schedule);

            Console.WriteLine("Вiдновлений стан розкладу:");
            foreach (var ad in schedule.GetAdvertisements())
            {
                Console.WriteLine($"{ad.Content}, {ad.StartTime}, тривалiсть: {ad.Duration} хв");
            }

            Console.ReadLine();
        }
    }
}/**/

//Observer Pattern (Спостерігач)
/*/
namespace ConsoleApp1
{
    public class Advertisement
    {
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
    }

    public interface IObserver
    {
        void Update(Advertisement ad);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(Advertisement ad);
    }

    public class Schedule : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private List<Advertisement> _advertisements = new List<Advertisement>();

        public void AddAdvertisement(Advertisement ad)
        {
            _advertisements.Add(ad);
            Notify(ad);
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Advertisement ad)
        {
            foreach (var observer in _observers)
            {
                observer.Update(ad);
            }
        }
    }

    public class ManagerObserver : IObserver
    {
        public void Update(Advertisement ad)
        {
            Console.WriteLine($"Сповiщення менеджеру: Додано нову рекламу - {ad.Content} з початком {ad.StartTime}");
        }
    }
    class Program
{
    static void Main()
    {
        var schedule = new Schedule();
        var managerObserver = new ManagerObserver();

        schedule.Attach(managerObserver);

        var ad1 = new Advertisement { Content = "Ad 1", StartTime = DateTime.Now, Duration = 30 };
        schedule.AddAdvertisement(ad1);

        var ad2 = new Advertisement { Content = "Ad 2", StartTime = DateTime.Now.AddMinutes(1), Duration = 45 };
        schedule.AddAdvertisement(ad2);

        Console.ReadLine();
    }
}
}/**/

/*
namespace ConsoleApp1
{
    public class Advertisement
    {
        public string Content { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }

    public Advertisement(string content, DateTime startTime, int duration)
    {
        Content = content;
        StartTime = startTime;
        Duration = duration;
    }
}

public abstract class AdvertisementState
{
    public abstract void Handle(AdvertisementContext context);
}

public class ScheduledState : AdvertisementState
{
    public override void Handle(AdvertisementContext context)
    {
        Console.WriteLine("Реклама запланована.");
    }
}

public class RunningState : AdvertisementState
{
    public override void Handle(AdvertisementContext context)
    {
        Console.WriteLine("Реклама в ефiрi.");
    }
}

public class CompletedState : AdvertisementState
{
    public override void Handle(AdvertisementContext context)
    {
        Console.WriteLine("Реклама завершена.");
    }
}

public class AdvertisementContext
{
    private AdvertisementState _state;

    public AdvertisementContext(AdvertisementState state)
    {
        _state = state;
    }

    public void SetState(AdvertisementState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }

class Program
{
    static void Main()
    {
        Advertisement ad = new Advertisement("Ad 1", DateTime.Parse("2023-10-01 10:00"), 30);
        AdvertisementContext context = new AdvertisementContext(new ScheduledState());

        context.Request();
        context.SetState(new RunningState());
        context.Request(); 
        context.SetState(new CompletedState());
        context.Request();
                Console.ReadLine();
            }
        }
    }
}
/**/
/**
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var ad = new Advertisement { Content = "Ad 1", StartTime = DateTime.Now, Duration = 30, TargetAudience = "Adults" };

            var ad2 = new Advertisement { Content = "Ad 2", StartTime = DateTime.Now, Duration = 25, TargetAudience = "Children" };
            var context = new AdvertisementContext(new PrimeTimeDisplayStrategy());


            context.ShowAdvertisement(ad);
            context.ShowAdvertisement(ad2);


            context.SetDisplayStrategy(new TargetedDisplayStrategy());
            context.ShowAdvertisement(ad);
            context.ShowAdvertisement(ad2);

            Console.ReadLine();
        }
    }

    public class Advertisement
    {
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string TargetAudience { get; set; }
    }

    public interface IAdvertisementDisplayStrategy
    {
        void Display(Advertisement ad);
    }

    public class PrimeTimeDisplayStrategy : IAdvertisementDisplayStrategy
    {
        public void Display(Advertisement ad)
        {
            Console.WriteLine($"Показ реклами '{ad.Content}' у прайм-тайм.");
        }
    }

    public class TargetedDisplayStrategy : IAdvertisementDisplayStrategy
    {
        public void Display(Advertisement ad)
        {
            Console.WriteLine($"Показ реклами '{ad.Content}' для аудиторiї: {ad.TargetAudience}.");
        }
    }

    public class AdvertisementContext
    {
        private IAdvertisementDisplayStrategy _displayStrategy;

        public AdvertisementContext(IAdvertisementDisplayStrategy displayStrategy)
        {
            _displayStrategy = displayStrategy;
        }

        public void SetDisplayStrategy(IAdvertisementDisplayStrategy displayStrategy)
        {
            _displayStrategy = displayStrategy;
        }

        public void ShowAdvertisement(Advertisement ad)
        {
            _displayStrategy.Display(ad);
        }
    }
}
/**/

/**
namespace ConsoleApp1
{
    public class Advertisement
    {
        public string Content { get; set; }
        public int Duration { get; set; }

        public Advertisement(string content)
        {
            Content = content;
            Duration = 0;
        }
    }

    public abstract class AdvertisementProcessor
    {
        public void ProcessAdvertisement(Advertisement ad)
        {
            CheckContent(ad);
            SetDuration(ad);
            ApplyTargeting(ad);
            ShowAdvertisement(ad);
        }

        protected abstract void CheckContent(Advertisement ad);
        protected abstract void SetDuration(Advertisement ad);
        protected abstract void ApplyTargeting(Advertisement ad);

        protected void ShowAdvertisement(Advertisement ad)
        {
            Console.WriteLine($"Показ реклами: {ad.Content}, тривалiсть: {ad.Duration} сек.");
        }
    }

    public class ShortAdvertisementProcessor : AdvertisementProcessor
    {
        protected override void CheckContent(Advertisement ad)
        {
            Console.WriteLine("Перевiрка контенту короткої реклами.");
        }

        protected override void SetDuration(Advertisement ad)
        {
            ad.Duration = 15;
        }

        protected override void ApplyTargeting(Advertisement ad)
        {
            Console.WriteLine("Цiльова аудиторiя для короткої реклами застосована.");
        }
    }

    public class LongAdvertisementProcessor : AdvertisementProcessor
    {
        protected override void CheckContent(Advertisement ad)
        {
            Console.WriteLine("Перевiрка контенту довгої реклами.");
        }

        protected override void SetDuration(Advertisement ad)
        {
            ad.Duration = 30;
        }

        protected override void ApplyTargeting(Advertisement ad)
        {
            Console.WriteLine("Цiльова аудиторiя для довгої реклами застосована.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ad = new Advertisement("Promo Video");

            var shortProcessor = new ShortAdvertisementProcessor();
            shortProcessor.ProcessAdvertisement(ad);

            var longProcessor = new LongAdvertisementProcessor();
            longProcessor.ProcessAdvertisement(ad);

            Console.ReadLine();
        }
    }
}
/**/

/**/
namespace ConsoleApp1
{
 
    public abstract class Advertisement
    {
        public abstract void Accept(IAdvertisementVisitor visitor);
    }

    public class LongAdvertisement : Advertisement
    {
        public int Duration { get; }
        public int Views { get; }

        public LongAdvertisement(int duration, int views)
        {
            Duration = duration;
            Views = views;
        }

        public override void Accept(IAdvertisementVisitor visitor)
        {
            visitor.VisitLongAdvertisement(this);
        }
    }

    public class ShortAdvertisement : Advertisement
    {
        public int Width { get; }
        public int Height { get; }

        public ShortAdvertisement(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override void Accept(IAdvertisementVisitor visitor)
        {
            visitor.VisitShortAdvertisement(this);
        }
    }

    public interface IAdvertisementVisitor
    {
        void VisitLongAdvertisement(LongAdvertisement longAd);
        void VisitShortAdvertisement(ShortAdvertisement shortAd);
    }

    public class CostCalculatorVisitor : IAdvertisementVisitor
    {
        public double TotalCost { get; private set; } = 0;

        public void VisitLongAdvertisement(LongAdvertisement longAd)
        {
            TotalCost += longAd.Duration * 0.5; // Розрахунок вартості для довгої реклами
        }

        public void VisitShortAdvertisement(ShortAdvertisement shortAd)
        {
            TotalCost += shortAd.Width * shortAd.Height * 0.2; // Розрахунок вартості для короткої реклами
        }
    }

    public class StatisticsCollectorVisitor : IAdvertisementVisitor
    {
        public int TotalViews { get; private set; } = 0;

        public void VisitLongAdvertisement(LongAdvertisement longAd)
        {
            TotalViews += longAd.Views; 
        }

        public void VisitShortAdvertisement(ShortAdvertisement shortAd)
        {
            // Для короткої реклами не без обліку переглядів
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ads = new List<Advertisement>
            {
                new LongAdvertisement(duration: 30, views: 1000),
                new ShortAdvertisement(width: 300, height: 250)
            };

            var costVisitor = new CostCalculatorVisitor();
            var statsVisitor = new StatisticsCollectorVisitor();

            foreach (var ad in ads)
            {
                ad.Accept(costVisitor);
                ad.Accept(statsVisitor);
            }

            Console.WriteLine($"Загальна вартiсть: {costVisitor.TotalCost}");
            Console.WriteLine($"Загальна кiлькiсть переглядiв: {statsVisitor.TotalViews}");
            Console.ReadLine();
        }
    }
}
/**/