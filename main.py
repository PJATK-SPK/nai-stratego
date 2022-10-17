from easyAI.Player import Human_Player
from easyAI import AI_Player, Negamax
from stratego import Stratego

# Stratego
# (PL - https://zabawnik.org/wystarczy-kartka-i-dlugopis)

# Rules:
# This is a strategy game formerly known as "The Funeral".
# It is said that it was played by impetuous regulars of port pubs.
#
# It is really exciting. In the original the playing field is a 7 × 7 or 8 × 8 square,
# but for simplicity this game has a 4 x 4 square game field.
#
# Players should use pens of two different colors.
# The one who begins to paint over any one box, the other does the same.
# If the painted squares fill a row, column or diagonal line (from edge to edge),
# you get as many points as the squares counted by the section you color (minimum 2 squares).
#
# It may happen that coloring one square "closes" even a few point-bearing sections,
# then each section is counted separately, and all points are added up and included.
#
# Have fun!

# How to run
# Please install:
# - Python
# - easyAI
# And then run this file in the console.

# Authors: Sandro (s20600) & Marcel (s21167)

if __name__ == "__main__":
    algorithm = Negamax(6)
    game = Stratego([Human_Player(), AI_Player(algorithm)])
    game.play()

    if game.scoring() > 0:
        print("You win! " + game.get_score_text())
    elif game.scoring() < 0:
        print("AI wins. " + game.get_score_text())
    else:
        print("Draw.")
