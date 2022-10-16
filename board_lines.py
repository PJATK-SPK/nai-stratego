class BoardLines():
    def __init__(self, boardSize):
        self.size = boardSize

    def get_all(self):
        return [
            self.__get_vertical_line(i) for i in range(self.size)
        ] + [
            self.__get_horizontal_line(i) for i in range(0, self.size ** 2, self.size)
        ] + [
            self.__get_diagonal_line(i, i) for i in range(0, self.size - 1, 1)
        ] + [
            self.__get_diagonal_line(i, 0) for i in range(self.size, (self.size ** 2) - self.size, self.size)
        ]

    def __get_vertical_line(self, index):
        result = [index + self.size * i for i in range(self.size)]
        return result

    def __get_horizontal_line(self, index):
        result = [index + i for i in range(self.size)]
        return result

    def __get_diagonal_line(self, index, reducer):
        result = [index + self.size * i +
                  i for i in range(self.size - reducer)]
        result = [i for i in result if i >= 0 and i < self.size ** 2]
        return result
