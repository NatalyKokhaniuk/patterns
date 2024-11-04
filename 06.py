#Template Pattern (Шаблонний метод)

class Advertisement:
    def __init__(self, content):
        self.content = content
        self.duration = 0

class AdvertisementProcessor:
    def process_advertisement(self, ad):
        self.check_content(ad)
        self.set_duration(ad)
        self.apply_targeting(ad)
        self.show_advertisement(ad)

    def check_content(self, ad):
        raise NotImplementedError

    def set_duration(self, ad):
        raise NotImplementedError

    def apply_targeting(self, ad):
        raise NotImplementedError

    def show_advertisement(self, ad):
        print(f"Показ реклами: {ad.content}, тривалість: {ad.duration} сек.")

class ShortAdvertisementProcessor(AdvertisementProcessor):
    def check_content(self, ad):
        print("Перевірка контенту короткої реклами.")

    def set_duration(self, ad):
        ad.duration = 15

    def apply_targeting(self, ad):
        print("Цільова аудиторія для відеореклами застосована.")

class LongAdvertisementProcessor(AdvertisementProcessor):
    def check_content(self, ad):
        print("Перевірка контенту довгої реклами.")

    def set_duration(self, ad):
        ad.duration = 30

    def apply_targeting(self, ad):
        print("Цільова аудиторія для довгої реклами застосована.")

ad = Advertisement("Promo Video")

short_processor = ShortAdvertisementProcessor()
short_processor.process_advertisement(ad)

long_processor = LongAdvertisementProcessor()
long_processor.process_advertisement(ad)
