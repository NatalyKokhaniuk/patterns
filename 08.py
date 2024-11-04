#Iterator Pattern (Ітератор)

class Advertisement:
    def __init__(self, content):
        self.content = content

class IIterator:
    def current(self):
        raise NotImplementedError

    def move_next(self):
        raise NotImplementedError

    def reset(self):
        raise NotImplementedError

class AdvertisementIterator(IIterator):
    def __init__(self, collection):
        self._collection = collection
        self._current_index = -1

    def current(self):
        return self._collection[self._current_index]

    def move_next(self):
        self._current_index += 1
        return self._current_index < self._collection.count()

    def reset(self):
        self._current_index = -1

class IAggregate:
    def create_iterator(self):
        raise NotImplementedError

class AdvertisementCollection(IAggregate):
    def __init__(self):
        self._advertisements = []

    def add(self, advertisement):
        self._advertisements.append(advertisement)

    def __getitem__(self, index):
        return self._advertisements[index]

    def count(self):
        return len(self._advertisements)

    def create_iterator(self):
        return AdvertisementIterator(self)

if __name__ == "__main__":
    collection = AdvertisementCollection()
    collection.add(Advertisement("Ad 1"))
    collection.add(Advertisement("Ad 2"))
    collection.add(Advertisement("Ad 3"))
    collection.add(Advertisement("Ad 1"))
    collection.add(Advertisement("Ad 5"))
    collection.add(Advertisement("Ad 123"))

    iterator = collection.create_iterator()
    while iterator.move_next():
        print(iterator.current().content)
