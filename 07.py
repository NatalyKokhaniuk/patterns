#Visitor Pattern (Відвідувач)
class Advertisement:
    def accept(self, visitor):
        pass

class LongAdvertisement(Advertisement):
    def __init__(self, duration, views):
        self.duration = duration
        self.views = views

    def accept(self, visitor):
        visitor.visit_Long_advertisement(self)

class ShortAdvertisement(Advertisement):
    def __init__(self, width, height):
        self.width = width
        self.height = height

    def accept(self, visitor):
        visitor.visit_Short_advertisement(self)

class AdvertisementVisitor:
    def visit_Long_advertisement(self, Long_ad):
        pass

    def visit_Short_advertisement(self, Short_ad):
        pass

class CostCalculatorVisitor(AdvertisementVisitor):
    def __init__(self):
        self.total_cost = 0

    def visit_Long_advertisement(self, Long_ad):
        self.total_cost += Long_ad.duration * 0.5

    def visit_Short_advertisement(self, Short_ad):
        self.total_cost += Short_ad.width * Short_ad.height * 0.2

class StatisticsCollectorVisitor(AdvertisementVisitor):
    def __init__(self):
        self.total_views = 0

    def visit_Long_advertisement(self, Long_ad):
        self.total_views += Long_ad.views

    def visit_Short_advertisement(self, Short_ad):
        pass


ads = [
    LongAdvertisement(duration=30, views=1000),
    ShortAdvertisement(width=300, height=250)
]

cost_visitor = CostCalculatorVisitor()
stats_visitor = StatisticsCollectorVisitor()

for ad in ads:
    ad.accept(cost_visitor)
    ad.accept(stats_visitor)

print(f"Загальна вартість: {cost_visitor.total_cost}")
print(f"Загальна кількість переглядів: {stats_visitor.total_views}")
