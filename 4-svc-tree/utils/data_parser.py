# Authors: Sandro Sobczynski, Marcel Pankanin

from utils.file_reader import FileReader
from pathlib import Path
import os


class DataParser():
    """ Class reponsible for parsing source data. """

    def parse(self, filename: str) -> list and list:
        """ 
            Parameters:
            filename (str): file name

            Returns: list of inputs (X) and outputs (Y)
        """
        path = Path(os.path.dirname(os.path.realpath(__file__)))
        path = path.parent.absolute()
        path = path / 'datasets' / filename

        text = FileReader().read(path)

        lines = text.split('\n')
        x = []  # array of all columns except last
        y = []  # array of last columns

        for line in lines:
            parts = line.split(';')
            x.append(parts[:-1])
            y.append(parts[-1])

        return x, y
