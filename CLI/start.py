import argparse
import sys


class LightManager(object):
    def __init__(self):
        parser = argparse.ArgumentParser(
            description='Pretends to be git',
            usage="""Lights remote controller
            The most used CLI are:
                start: turns given lights on
                mode: changes mode of given lights
                color: changes color of give lights
            """)
        parser.add_argument('command', help='Subcommand to run')
        # parse_args defaults to [1:] for args, but you need to
        # exclude the rest of the args too, or validation will fail
        args = parser.parse_args(sys.argv[1:2])
        if not hasattr(self, args.command):
            print('Unrecognized command')
            parser.print_help()
            exit(1)
        # use dispatch pattern to invoke method with same name
        getattr(self, args.command)()

    def start(self):
        parser = argparse.ArgumentParser(
            description='Turns given lights on')
        # prefixing the argument with -- means it's optional
        parser.add_argument('id', nargs='*', metavar="num", type=int)
        # now that we're inside a subcommand, ignore the first
        # THREE argvs (python, start.py, start) ignores first 3 using [3:]
        args = parser.parse_args(sys.argv[3:])
        print(f'Turning lights {args.id} on')

    def mode(self):
        parser = argparse.ArgumentParser(
            description="Changes mode of give lights")
        parser.add_argument('id', nargs='*', metavar="num", type=int)
        parser.add_argument('--mode', nargs='1', metavar="num", type=int, default=0)
        args = parser.parse_args(sys.argv[3:])
        print(f'Changing mode of lights {args.id} to {args.mode}')

LightManager()
