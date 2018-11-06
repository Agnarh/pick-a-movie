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
    IsMovieExists = false;
    MovieList = [];
    PickedMovie = None;
}

let initState () = emptyState

let isTargetMovie id movie = movie.Id = id

let update action state =
    match action with
    | AddMovie ->
        if not state.IsMovieExists then
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
        else
            state
    | DeleteMovie id ->
        let isNotTargetMovie = isTargetMovie id >> not
        { state with
            MovieList = state.MovieList |> List.filter isNotTargetMovie
            PickedMovie = state.PickedMovie |> Option.filter isNotTargetMovie
        }
    | PickMovie id ->
        { state with PickedMovie = state.MovieList |> List.tryFind (isTargetMovie id)}
    | ChangeField descr ->
        { state with
            Field = descr
            IsMovieExists = 
                state.MovieList
                |> List.tryFind (fun movie -> movie.Name = descr)
                |> Option.isSome }
    | ToggleEditMovie (id, isEditing) -> 
        { state with 
            MovieList = state.MovieList |> List.map (fun movie ->
                if movie.Id = id then
                    { movie with IsEditing = isEditing }
                else 
                    movie)}
    | EditMovieName (id, name) ->
        { state with 
            MovieList = state.MovieList |> List.map (fun movie ->
                if movie.Id = id then
                    { movie with Name = name }
                else 
                    movie)
            PickedMovie = 
                match state.PickedMovie with
                | Some movie when movie.Id = id -> Some { movie with Name = name }
                | Some movie -> Some movie
                | None -> None
        }
