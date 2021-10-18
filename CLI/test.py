from argparse import ArgumentParser


def get_parser(cmd):
    """Returns a parser object for a given command"""
    # Instantiate the parser object, add the appropriate arguments for the command
    if cmd == "add":
        return add_parser()


def add_parser():
    parser = ArgumentParser(description="An addition program")
    # add argument
    parser.add_argument("add", nargs='*', metavar="num", type=int,
                        help="All the numbers separated by spaces will be added.")
    return parser
    # parse the arguments from standard input
    args = parser.parse_args()

    # check if add argument has any input data.
    # If it has, then print sum of the given numbers
    if len(args.add) != 0:
        print(sum(args.add))


def main():
    while True:
        try:
            in_line = input('> ')
            if not in_line.strip():  # Quit if empty
                break
            args = in_line.split()
            parser = get_parser(args[0])
            opts = parser.parser_args(args)
            # Do stuff with opts depending on command
        except EOFError:
            break
        except SystemExit:
            pass  # Prevent failures from killing the program by trapping sys.exit()


main()
