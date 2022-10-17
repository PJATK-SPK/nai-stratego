class StrategoMap():
    """ Class responsible for retrieving Stratego lines for a given board size. """

    def __init__(self, boardSize: int):
        self.size = boardSize

    def get_all(self) -> list:
        """ Returns list with all lines for a given board size. """
        return [
            self.__get_vertical_line(i) for i in range(self.size)
        ] + [
            self.__get_horizontal_line(i) for i in range(0, self.size ** 2, self.size)
        ] + self.__get_diagonal_lines(4) + self.__get_anti_diagonal_line(4)

    def __get_vertical_line(self, index: int) -> list:
        """ Returns single vertical line for a given board index. """
        return [index + self.size * i for i in range(self.size)]

    def __get_horizontal_line(self, index: int) -> list:
        """ Returns single horizontal line for a given board index. """
        return [index + i for i in range(self.size)]

    def __get_diagonal_lines(self) -> list:
        """ Returns list with all diagonal lines for a given board size. """

        # Core diagonal line
        core = [i * self.size + i for i in range(self.size)]

        # Child lines to the left
        left = []
        for i in reversed(range(1, self.size)):
            limited = core[-i:]
            itm = [e - (self.size - i) for e in limited]
            if len(itm) >= 0:
                left.append(itm)

        # Child lines to the right
        right = []
        for i in range(1, self.size):
            limited = core[:self.size-i]
            itm = [x + i for x in limited]
            if len(itm) > 1:
                right.append(itm)

        result = [core] + left + right
        return result

    def __get_anti_diagonal_line(self) -> list:
        """ Returns list with all anti-diagonal lines for a given board size. """

        # Core anti-diagonal line
        core = [i * self.size + (self.size - 1 - i) for i in range(self.size)]

        # Child lines to the left
        left = []
        for i in range(1, self.size):
            limited = core[:self.size-i]
            itm = [x - i for x in limited]
            if len(itm) > 1:
                left.append(itm)

        # Child lines to the right
        right = []
        for i in reversed(range(1, self.size)):
            limited = core[-i:]
            itm = [e + (self.size - i) for e in limited]
            if len(itm) > 1:
                right.append(itm)

        result = [core] + left + right
        return result
