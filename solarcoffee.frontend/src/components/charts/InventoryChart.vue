<template>
  <div>
      <apexchart
        type="area"
        :width="'100%'"
        height="300"
        :options="options"
        :series="series"
        >

          
      </apexchart>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { IInventoryTimeline } from "@/types/InventoryGraph";
import { Sync, Get } from 'vuex-pathify';


@Component({
    name: "InventoryChart",
    components: {}
})


export default class Invntorychart extends Vue {

//vuex-pathify syntax for making mutations. state is managed in store
@Sync("snapshotTimeline")
snapshotTimeline: IInventoryTimeline;

//getter, computed property. will ensure to always get the newest value from the store
@Get("isTimelineBuilt")
timelineBuild?: boolean;

  get options() {
    return {
      dataLabels: {enabled: false},
      fill: {
        type: "gradient"
      },
      stroke: {
        curve: "smooth"
      },
      xaxis: {
        categories: this.snapshotTimeline.timeline,
        type: "datetime"
      }
    };
  }

  get series() {
    return this.snapshotTimeline.productInventorySnapshots.map(snapshot => ({
      name: snapshot.productId,
      data: snapshot.quantityOnHand
    }));
  }

  async created() {
    await this.$store.dispatch("assignSnapshots");
  }
}
</script>

<style scoped lang="sass">

</style>