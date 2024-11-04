# Mediator Pattern (Посередник)
class Advertisement:
    def __init__(self, content, duration):
        self.content = content
        self.duration = duration

class Mediator:
    def __init__(self):
        self.departments = []

    def register_department(self, department):
        self.departments.append(department)

    def send(self, message, sender):
        for dept in self.departments:
            if dept != sender:
                dept.receive(message)

class Department:
    def __init__(self, mediator):
        self._mediator = mediator

    def receive(self, message):
        pass

class ScheduleDepartment(Department):
    def plan_ad(self, ad):
        self._mediator.send(f"Planned ad with content: {ad.content}", self)

    def receive(self, message):
        print(f"Schedule Department received: {message}")

class FinanceDepartment(Department):
    def approve_ad(self, ad):
        self._mediator.send(f"Approved ad with content: {ad.content}", self)

    def receive(self, message):
        print(f"Finance Department received: {message}")


mediator = Mediator()
schedule_department = ScheduleDepartment(mediator)
finance_department = FinanceDepartment(mediator)

mediator.register_department(schedule_department)
mediator.register_department(finance_department)

ad = Advertisement("New Ad", 30)
ad2 = Advertisement("Ad 2", 25)

schedule_department.plan_ad(ad)
finance_department.approve_ad(ad)
schedule_department.plan_ad(ad2)
finance_department.approve_ad(ad2)
