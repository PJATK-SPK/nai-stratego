# Authors: Sandro Sobczynski, Marcel Pankanin

from stratego_map import StrategoMap


class StrategoMapManager():
    """ Class reponsible for managing the map. """

    map: StrategoMap

    def __init__(self, boardSize):
        self.map = StrategoMap(boardSize)

    def get_player_lines(self, board: list, player: int) -> list:
        """ Returns:
            list: List with all lines for a given board and player. 
        """
        result = []
        for line in self.map.get_all():
            if all([board[i] == player for i in line]):
                result.append(line)
        return result

    def is_possible_to_make_a_line_for(self, board: list, player: int) -> bool:
        """ Returns:
            bool: True if it is possible to make a line for a given board and player. 
        """
        freeLines = self.get_free_lines_for(board, player)
        return len(freeLines) > 0

    def get_free_lines_for(self, board: list, player: int) -> list:
        """ Returns:
            list: List with all free lines for a given board and player. 
        """
        result = []
        for line in self.map.get_all():
            if all([board[i] == 0 or board[i] == player for i in line]):
                result.append(line)
        return result
