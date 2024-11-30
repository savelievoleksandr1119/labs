class RenovationModel {
    constructor() {
        this.renovations = 
[
  {
    "id": 1,
    "name": "Optimize Space with Multipurpose Furniture",
    "description": "Choose furniture that serves multiple purposes, such as a sofa bed or a dining table with built-in storage, to maximize space efficiency and maintain a clean, organized look."
  },
  {
    "id": 2,
    "name": "Incorporate Natural Elements",
    "description": "Add warmth and freshness to your interiors by including natural materials like wood, stone, or greenery. Consider indoor plants, wooden beams, or a natural stone backsplash for texture."
  },
  {
    "id": 3,
    "name": "Play with Statement Lighting",
    "description": "Invest in unique light fixtures to add character to your space. Pendant lights, chandeliers, or even LED strips can create focal points and enhance the ambiance."
  },
  {
    "id": 4,
    "name": "Experiment with Bold Colors and Patterns",
    "description": "Don't shy away from using bold colors or statement wallpapers. An accent wall with a vibrant hue or geometric patterns can create visual interest and refresh your interiors."
  },
  {
    "id": 5,
    "name": "Focus on Sustainability",
    "description": "Opt for eco-friendly materials and energy-efficient appliances. Reclaimed wood, recycled glass countertops, or solar-powered lighting are excellent ways to make your renovation environmentally conscious."
  }
]
      }

    getAllRenovations() {
        return this.renovations;
    }

    addRenovation(renovation) {
        this.renovations.push(renovation);
    }
}

module.exports = new RenovationModel();