use rand::Rng;
use wasm_bindgen::prelude::*;

#[cfg_attr(all(target_arch = "wasm32", target_os = "unknown"), wasm_bindgen)]
pub struct Raffle {
    participants: Vec<Participant>,
}

#[cfg_attr(all(target_arch = "wasm32", target_os = "unknown"), wasm_bindgen)]
impl Raffle {
    #[cfg_attr(
        all(target_arch = "wasm32", target_os = "unknown"),
        wasm_bindgen(constructor)
    )]
    pub fn new() -> Raffle {
        Raffle {
            participants: Vec::new(),
        }
    }

    #[cfg_attr(all(target_arch = "wasm32", target_os = "unknown"), wasm_bindgen)]
    pub fn add_participant(&mut self, participant: Participant) {
        self.participants.push(participant);
    }

    #[cfg_attr(all(target_arch = "wasm32", target_os = "unknown"), wasm_bindgen)]
    pub fn draw_winner(&self) -> Participant {
        let mut rng = rand::rngs::OsRng;

        let winner = &self.participants[rng.gen_range(0, &self.participants.len())];

        winner.clone()
    }
}

#[cfg_attr(all(target_arch = "wasm32", target_os = "wasi"), wasm_bindgen)]
pub fn text_raffle(data: &str) -> String {
    let mut raffle = Raffle::new();

    for line in data.lines() {
        raffle.add_participant(line.into());
    }

    raffle.draw_winner().display_name()
}

#[cfg_attr(all(target_arch = "wasm32", target_os = "unknown"), wasm_bindgen)]
#[derive(Clone)]
pub struct Participant {
    first_name: String,
    last_name: Option<String>,
}

#[cfg_attr(all(target_arch = "wasm32", target_os = "unknown"), wasm_bindgen)]
impl Participant {
    #[cfg_attr(
        all(target_arch = "wasm32", target_os = "unknown"),
        wasm_bindgen(constructor)
    )]
    pub fn new(first_name: String, last_name: Option<String>) -> Participant {
        Participant {
            first_name: first_name,
            last_name: last_name,
        }
    }

    #[cfg_attr(
        all(target_arch = "wasm32", target_os = "unknown"),
        wasm_bindgen(getter)
    )]
    pub fn first_name(&self) -> String {
        self.first_name.clone()
    }

    #[cfg_attr(
        all(target_arch = "wasm32", target_os = "unknown"),
        wasm_bindgen(setter)
    )]
    pub fn set_first_name(&mut self, first_name: String) {
        self.first_name = first_name;
    }

    #[cfg_attr(
        all(target_arch = "wasm32", target_os = "unknown"),
        wasm_bindgen(getter)
    )]
    pub fn last_name(&self) -> Option<String> {
        self.last_name.clone()
    }

    #[cfg_attr(
        all(target_arch = "wasm32", target_os = "unknown"),
        wasm_bindgen(setter)
    )]
    pub fn set_last_name(&mut self, last_name: Option<String>) {
        self.last_name = last_name;
    }

    #[cfg_attr(all(target_arch = "wasm32", target_os = "unknown"), wasm_bindgen())]
    pub fn display_name(&self) -> String {
        let mut result = String::new();
        result.push_str(&self.first_name);
        if let Some(last_name) = &self.last_name {
            result.push(' ');
            result.push_str(last_name);
        }

        result
    }
}

impl From<&str> for Participant {
    fn from(row: &str) -> Self {
        let vec: Vec<&str> = row.split(",").collect();

        Participant {
            first_name: vec[0].to_owned(),
            last_name: none_if_empty(vec[1]),
        }
    }
}

fn none_if_empty(value: &str) -> Option<String> {
    if value.is_empty() {
        None
    } else {
        Some(value.to_owned())
    }
}
