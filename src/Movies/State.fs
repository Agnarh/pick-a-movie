module Movies.State

open Types

let newMovie name id = {
    Name = name;
    Id = id;
    IsEditing = false;
}

let emptyState = {
    CurrentId = 0;
    Field = "";
    MovieList = [];
    PickedMovie = None;
}

let initState () = emptyState

let getMovieById id = 
    List.find (fun movie -> movie.Id = id)

let update action state =
    match action with
    | AddMovie ->
        let movies =
            if System.String.IsNullOrEmpty state.Field then
                state.MovieList
            else
                newMovie state.Field state.CurrentId :: state.MovieList
        { state with
            MovieList = movies
            CurrentId = state.CurrentId + 1
            Field = ""
        }
    | DeleteMovie id ->
        let pickedMovie =
            match state.PickedMovie with
            | Some movie when id <> movie.Id -> Some movie
            | Some _ | None -> None
        { state with
            MovieList = state.MovieList |> List.filter (fun movie -> movie.Id <> id)
            PickedMovie = pickedMovie
        }
    | PickMovie id ->
        let movie = state.MovieList |> getMovieById id
        { state with PickedMovie = Some movie }
    | ChangeField descr ->
        { state with Field = descr }
    | ToggleEditMovie (id, isEditing) -> state