#Strategy Pattern (Стратегія)

class Advertisement:
    def __init__(self, content, start_time, duration, target_audience):
        self.content = content
        self.start_time = start_time
        self.duration = duration
        self.target_audience = target_audience

class AdvertisementDisplayStrategy:
    def display(self, ad):
        pass

class PrimeTimeDisplayStrategy(AdvertisementDisplayStrategy):
    def display(self, ad):
        print(f"Показ реклами '{ad.content}' у прайм-тайм.")

class TargetedDisplayStrategy(AdvertisementDisplayStrategy):
    def display(self, ad):
        print(f"Показ реклами '{ad.content}' для аудиторії: {ad.target_audience}.")

class AdvertisementContext:
    def __init__(self, display_strategy):
        self._display_strategy = display_strategy

    def set_display_strategy(self, display_strategy):
        self._display_strategy = display_strategy

    def show_advertisement(self, ad):
        self._display_strategy.display(ad)

ad = Advertisement("Ad 1", "2023-10-01 20:00", 30, "Adults")
ad2 = Advertisement("Ad 2", "2023-10-01 19:00", 30, "Children")
context = AdvertisementContext(PrimeTimeDisplayStrategy())

context.show_advertisement(ad)
context.show_advertisement(ad2)

context.set_display_strategy(TargetedDisplayStrategy())
context.show_advertisement(ad)
context.show_advertisement(ad2)
