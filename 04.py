# State Pattern (Стан)
class Advertisement:
    def __init__(self, content, start_time, duration):
        self.content = content
        self.start_time = start_time
        self.duration = duration

class AdvertisementState:
    def handle(self, context):
        pass

class ScheduledState(AdvertisementState):
    def handle(self, context):
        print("Реклама запланована.")

class RunningState(AdvertisementState):
    def handle(self, context):
        print("Реклама в ефірі.")

class CompletedState(AdvertisementState):
    def handle(self, context):
        print("Реклама завершена.")

class AdvertisementContext:
    def __init__(self, state):
        self._state = state

    def set_state(self, state):
        self._state = state

    def request(self):
        self._state.handle(self)

ad = Advertisement("Ad 1", "2023-10-01 10:00", 30)
context = AdvertisementContext(ScheduledState())

context.request()  
context.set_state(RunningState())
context.request() 
context.set_state(CompletedState())
context.request() 
