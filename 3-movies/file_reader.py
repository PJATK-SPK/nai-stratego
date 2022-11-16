# Authors: Sandro Sobczynski, Marcel Pankanin

import os


class FileReader():
    """ Class reponsible for reading file data. """

    def read(self, filename: str) -> str:
        """ 
            Parameters:
            filename (str): file name

            Returns: 
            str: full readed text
        """
        file = open(os.path.dirname(
            os.path.realpath(__file__)) + '/' + filename, mode='r', encoding='utf-8-sig')
        text = file.read()
        file.close()
        return text
