# Authors: Sandro Sobczynski, Marcel Pankanin

class FileReader():
    """ Class reponsible for reading file data. """

    def read(self, fullpath: str) -> str:
        """ 
            Parameters:
            filename (str): file name

            Returns: 
            str: full readed text
        """
        file = open(fullpath, mode='r', encoding='utf-8-sig')
        text = file.read()
        file.close()
        return text
