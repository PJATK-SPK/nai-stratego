from easyAI import TwoPlayerGame
from config import BOARD_SIZE
from stratego_map_manager import StrategoMapManager


class Stratego(TwoPlayerGame):
    """ Class responsible for game rules. """

    def __init__(self, players):
        self.players = players
        self.manager = StrategoMapManager(BOARD_SIZE)
        self.board = [0 for i in range(BOARD_SIZE ** 2)]
        self.current_player = 1  # player 1 starts.

    def possible_moves(self):
        """ Returns a list of possible moves. """
        return [i + 1 for i, e in enumerate(self.board) if e == 0]

    def make_move(self, move):
        """ Places a piece on the board. """
        self.board[int(move) - 1] = self.current_player

    def unmake_move(self, move):
        """ Undoes given move. """
        self.board[int(move) - 1] = 0

    def lose(self):
        """ Returns True if the game if is impossible to make a line and player has smaller score. """
        isImpossibleToMakeALine = not self.manager.is_possible_to_make_a_line_for(
            self.board, self.current_player)
        currentPlayerScore = self.__get_score_for(self.current_player)
        opponentScore = self.__get_score_for(self.opponent_index)
        result = isImpossibleToMakeALine and currentPlayerScore < opponentScore
        return result

    def is_over(self):
        """ Returns True if the game is over. """
        noPossibleMoves = self.possible_moves() == []
        isImpossibleToMakeALine = not self.manager.is_possible_to_make_a_line_for(
            self.board, self.current_player)
        result = noPossibleMoves or isImpossibleToMakeALine
        return result

    def show(self):
        """ Shows the board. """
        print(
            "\n"
            + "\n".join(
                [
                    " ".join([[".", "1", "2"][self.board[BOARD_SIZE * j + i]]
                             for i in range(BOARD_SIZE)])
                    for j in range(BOARD_SIZE)
                ]
            )
        )

    def scoring(self):
        """ Returns score for a given player. """
        return self.__get_score_for(self.current_player) - self.__get_score_for(self.opponent_index)

    def get_score_text(self):
        """ Returns score text for a given player. """
        return "Player score: {0}, AI score: {1}".format(
            self.__get_score_for(1), self.__get_score_for(2))

    def __get_score_for(self, player: int) -> int:
        """ Returns score for a given player. """
        playerLines = self.manager.get_player_lines(
            self.board, player)
        playerScore = sum([len(line) for line in playerLines])
        return playerScore
