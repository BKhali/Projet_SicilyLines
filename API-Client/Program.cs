using API_Client;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/usersitems", () => ClientDAO.getUsers());

app.MapGet("/reservationsitems", () => ReservationDAO.getReservation());

app.MapGet("/traverseitems", () => TraverseDAO.getTraverse());



app.MapGet("/reservationsfuturitems/{idcli}", (int idcli) =>
    ReservationDAO.getReservationfutur(idcli)
        is List<Reservation> u
            ? Results.Ok(u)
            : Results.NotFound());
app.MapGet("/reservationspasseitems/{idcli}", (int idcli) =>
    ReservationDAO.getReservationpasse(idcli)
        is List<Reservation> u
            ? Results.Ok(u)
            : Results.NotFound());

app.MapGet("/traversepasseitems/{idcli}", (int idcli) =>
    TraverseDAO.getTraversepasse(idcli)
        is List<Traverse> u
            ? Results.Ok(u)
            : Results.NotFound());

app.MapGet("/traversefuturitems/{idcli}", (int idcli) =>
    TraverseDAO.getTraversefutur(idcli)
        is List<Traverse> u
            ? Results.Ok(u)
            : Results.NotFound());

app.MapGet("/usersitems/{pseudo}", (string pseudo) =>
    ClientDAO.trouveClientpseudo(pseudo)
        is Client u
            ? Results.Ok(u)
            : Results.NotFound());

app.MapGet("/traverseitems/{cli}", (int cli) =>
    TraverseDAO.getTraversecli(cli)
        is List<Traverse> u
            ? Results.Ok(u)
            : Results.NotFound());

app.MapPut("/usersitems", (Client u, int num, string adr) =>
{
    ClientDAO.updateClient(u, num, adr);


});

app.Run();
