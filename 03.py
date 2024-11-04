#Observer Pattern (Спостерігач)

from datetime import datetime

class Advertisement:
    def __init__(self, content, start_time, duration):
        self.content = content
        self.start_time = start_time
        self.duration = duration

class IObserver:
    def update(self, ad):
        pass

class ISubject:
    def attach(self, observer):
        pass

    def detach(self, observer):
        pass

    def notify(self, ad):
        pass

class Schedule(ISubject):
    def __init__(self):
        self._observers = []
        self._advertisements = []

    def add_advertisement(self, ad):
        self._advertisements.append(ad)
        self.notify(ad)

    def attach(self, observer):
        self._observers.append(observer)

    def detach(self, observer):
        self._observers.remove(observer)

    def notify(self, ad):
        for observer in self._observers:
            observer.update(ad)

class ManagerObserver(IObserver):
    def update(self, ad):
        print(f"Сповіщення менеджеру: Додано нову рекламу - {ad.content} з початком {ad.start_time}")

# Використання
schedule = Schedule()
manager_observer = ManagerObserver()

# Додаємо менеджера як спостерігача до розкладу
schedule.attach(manager_observer)

ad1 = Advertisement("Ad 1", datetime.now(), 30)
schedule.add_advertisement(ad1)

ad2 = Advertisement("Ad 2", datetime.now(), 45)
schedule.add_advertisement(ad2)
