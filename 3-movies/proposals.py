# Authors: Sandro Sobczynski, Marcel Pankanin

class Proposals():
    """ Class reponsible for analyzing readed data. """

    def get(self, user: str, ratings: list) -> list:
        """ 
            Parameters:
            user (str): User name
            ratings (list): List of { user, movie, rating }

            Returns: 
            list: 2x list of movie name (str) - to_watch, to_not_watch
        """
        watched_movies = []
        for rating in ratings:
            if rating['user'] == user:
                watched_movies.append(rating['movie'])

        to_watch = []
        to_not_watch = []
        for rating in ratings:
            if rating['user'] != user:
                if rating['rating'] >= 5 and rating['movie'] not in watched_movies:
                    to_watch.append(rating['movie'])
                else:
                    to_not_watch.append(rating['movie'])
        return to_watch, to_not_watch
