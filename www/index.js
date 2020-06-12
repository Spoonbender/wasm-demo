import * as raffle_lib from "./wasm/raffle_core";
const raffle = new raffle_lib.Raffle();
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
raffle.add_participant(new raffle_lib.Participant("Vered", "Flis Segal"));
alert("The winner is... " + raffle.draw_winner().display_name() + "!");

