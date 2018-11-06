module Movies.Types

type MovieId = int

type Movie = {
    Id: MovieId;
    Name: string;
    IsEditing: bool;
}

type State = {
    CurrentId: int;
    Field: string;
    IsMovieExists: bool;
    MovieList: Movie list;
    PickedMovie: Movie option;
}

type Actions =
    | AddMovie
    | DeleteMovie of MovieId
    | PickMovie of MovieId
    | ChangeField of string
    | ToggleEditMovie of MovieId * bool
    | EditMovieName of MovieId * string