# Authors: Sandro Sobczynski, Marcel Pankanin

from utils.data_parser import DataParser

if __name__ == "__main__":
    glass_x, glass_y = DataParser().parse('glass.csv')
    wheat_seeds_x, wheat_seeds_y = DataParser().parse('glass.csv')
    print(glass_x)
    print(wheat_seeds_y)
