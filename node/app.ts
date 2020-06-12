import raffle_lib = require("./wasm/raffle_core");
const raffle: raffle_lib.Raffle = new raffle_lib.Raffle();

raffle.add_participant(new raffle_lib.Participant("Magnus", "Mårtensson"));
raffle.add_participant(new raffle_lib.Participant("Alon", "Fliess"));
raffle.add_participant(new raffle_lib.Participant("Eran", "Stiller"));
raffle.add_participant(new raffle_lib.Participant("Amir", "Zuker"));
raffle.add_participant(new raffle_lib.Participant("Vitali", "Zaidman"));
raffle.add_participant(new raffle_lib.Participant("Erez", "Pedro"));
raffle.add_participant(new raffle_lib.Participant("Alex", "Pshul"));
raffle.add_participant(new raffle_lib.Participant("Moaid", "Hathot"));
raffle.add_participant(new raffle_lib.Participant("Ronen", "Levinson"));
raffle.add_participant(new raffle_lib.Participant("Nir", "Dobovizki"));
raffle.add_participant(new raffle_lib.Participant("Eyal", "Ellenbogen"));
raffle.add_participant(new raffle_lib.Participant("Michael", "Donkhin"));
raffle.add_participant(new raffle_lib.Participant("Vered", "Flis"));

console.log("Drawing winner...");
console.log(raffle.draw_winner().display_name());