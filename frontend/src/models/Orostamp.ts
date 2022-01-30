import IOroStamp from "./IOroStamp"

export default class OroStamp {
  public id: number
  public userId: number
  public punchAt: Date
  public isIn: Boolean

  constructor(data: IOroStamp) {
    this.id = data.id
    this.userId = data.userId
    this.punchAt = new Date(data.punchAt)
    this.isIn = data.isIn
  }
}
