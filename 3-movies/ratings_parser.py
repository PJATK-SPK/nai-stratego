from file_reader import FileReader


class RatingsParser():
    """ Class reponsible for parsing ratings data. """

    def parse(self, filename: str) -> list:
        """ Returns:
            list: List of { user, movie, rating }
        """
        text = FileReader().read(filename)
        lines = text.split('\n')
        result = []

        for line in lines:
            items = line.split(';')
            user = items[0]
            movie = 'none'
            score = -1
            trigger = 0
            for (index, item) in enumerate(items):
                if index == 0 or not item.strip():
                    continue

                if trigger == 0:
                    movie = item
                    trigger = 1
                elif trigger == 1:
                    score = int(item)
                    trigger = 0
                    result.append({
                        'user': user,
                        'movie': movie,
                        'rating': score
                    })
        return result
