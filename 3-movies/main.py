import argparse
import random
from ratings_parser import RatingsParser
from proposals import Proposals


def build_arg_parser() -> argparse.ArgumentParser:
    """ Returns:
        List with arguments.
    """
    parser = argparse.ArgumentParser(
        description='Get movies propositions for specified user.')
    parser.add_argument('--user', dest='user', required=True, help='User')
    return parser


if __name__ == "__main__":
    # user = build_arg_parser().parse_args().user
    user = 'Sandro Sobczynski'
    ratings = RatingsParser().parse('ratings.csv')

    users = map(lambda x: x['user'], ratings)
    if user not in users:
        print(f"User '{user}' not found.")
        exit(1)

    proposals = Proposals().get(user, ratings)

    random.shuffle(proposals[0])
    random.shuffle(proposals[1])

    movies_to_watch = ', '.join(proposals[0][:5])
    movies_to_not_watch = ', '.join(proposals[1][:5])

    print(f"Movies to watch for '{user}': {movies_to_watch}")
    print(f"Movies to not watch for '{user}': {movies_to_not_watch}")
