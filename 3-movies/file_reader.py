import os


class FileReader():
    """ Class reponsible for reading file data. """

    def read(self, filename: str) -> str:
        file = open(os.path.dirname(
            os.path.realpath(__file__)) + '/' + filename, mode='r', encoding='utf-8-sig')
        text = file.read()
        file.close()
        return text
