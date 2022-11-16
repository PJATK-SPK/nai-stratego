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
                avg_rating = self.get_avg_rating(
                    rating['movie'], ratings)

                if avg_rating >= 5 and rating['movie'] not in watched_movies and rating['movie'] not in to_watch:
                    to_watch.append(rating['movie'])
                elif avg_rating < 5 and rating['movie'] not in to_not_watch:
                    to_not_watch.append(rating['movie'])
        return to_watch, to_not_watch

    def get_avg_rating(self, movie: str, ratings: list) -> float:
        """ 
            Parameters:
            movie (str): Movie name
            ratings (list): List of { user, movie, rating }

            Returns: 
            float: Average rating
        """
        sum = 0
        count = 0
        for rating in ratings:
            if rating['movie'] == movie:
                sum += rating['rating']
                count += 1
        return sum / count
