from easyAI.Player import Human_Player
from easyAI import AI_Player, Negamax
from stratego import Stratego

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
