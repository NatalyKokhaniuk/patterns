#Memento Pattern (Хранитель)
class Advertisement:
    def __init__(self, content, start_time, duration):
        self.content = content
        self.start_time = start_time
        self.duration = duration

class ScheduleMemento:
    def __init__(self, state):
        self.state = [ad for ad in state]

class Schedule:
    def __init__(self):
        self._advertisements = []

    def add_advertisement(self, ad):
        self._advertisements.append(ad)

    def remove_advertisement(self, ad):
        self._advertisements.remove(ad)

    def save(self):
        return ScheduleMemento(self._advertisements)

    def restore(self, memento):
        self._advertisements = [ad for ad in memento.state]

    def get_advertisements(self):
        return self._advertisements

class ScheduleCaretaker:
    def __init__(self):
        self._history = []

    def save_state(self, schedule):
        self._history.append(schedule.save())

    def undo(self, schedule):
        if self._history:
            schedule.restore(self._history.pop())

# Використання
import datetime

schedule = Schedule()
caretaker = ScheduleCaretaker()

ad1 = Advertisement("Ad 1", datetime.datetime.now(), 30)
ad2 = Advertisement("Ad 2", datetime.datetime.now() + datetime.timedelta(minutes=1), 45)

schedule.add_advertisement(ad1)
caretaker.save_state(schedule)

schedule.add_advertisement(ad2)
caretaker.save_state(schedule)

schedule.remove_advertisement(ad1)

# Відновлення попереднього стану
caretaker.undo(schedule)

print("Відновлений стан розкладу:")
for ad in schedule.get_advertisements():
    print(f"{ad.content}, {ad.start_time}, тривалість: {ad.duration} хв")
