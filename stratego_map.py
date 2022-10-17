# Authors: Sandro Sobczynski, Marcel Pankanin
class StrategoMap():
    """
    Class responsible for retrieving Stratego lines for a given board size.

    The board positions are numbered as follows:
    1 2 3 4
    5 .....
    """

    def __init__(self, boardSize: int):
        """ Parameters:
            boardSize (int): Stratego horizontal/vertical board size
        """
        self.size = boardSize

    def get_all(self) -> list:
        """ Returns:
            list: All lines for a given board size
        """
        return [
            self.__get_vertical_line(i) for i in range(self.size)
        ] + [
            self.__get_horizontal_line(i) for i in range(0, self.size ** 2, self.size)
        ] + self.__get_diagonal_lines() + self.__get_anti_diagonal_line()

    def __get_vertical_line(self, index: int) -> list:
        """ Parameters:
            index (int): Board index

            Returns:
            list: Single vertical line for a given board index.
        """
        return [index + self.size * i for i in range(self.size)]

    def __get_horizontal_line(self, index: int) -> list:
        """ Parameters:
            index (int): Board index

            Returns:
            list: Single horizontal line for a given board index.
        """
        return [index + i for i in range(self.size)]

    def __get_diagonal_lines(self) -> list:
        """ Returns:
            list: All diagonal lines for a given board size.
        """

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
        """ Returns:
            list: All opposite diagonal lines for a given board size.
        """

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
