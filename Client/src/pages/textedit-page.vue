<template>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="inputControl">Input</label>
                    <dx-text-area id="inputControl"
                                  v-model="inputText"
                                  :placeholder="''"
                                  :height="150"
                                  :stylingMode="'outlined'"></dx-text-area>
                </div>
                <div class="form-group">
                    <label for="instructionControl">Instructions</label>
                    <dx-text-area id="instructionControl"
                                  v-model="instructionText"
                                  :placeholder="'e.g. Fix grammar and spelling'"
                                  :height="150"
                                  :stylingMode="'outlined'"></dx-text-area>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="responseControl">AI Response</label>
                    <dx-text-area id="responseControl"
                                  v-model="aiResponse"
                                  placeholder=""
                                  :height="300"
                                  :stylingMode="'outlined'"
                                  readonly></dx-text-area>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-12">
                <dx-button text="Submit" @click="submitRequest" :stylingMode="'contained'"></dx-button>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from "vue";
    import { DxTextArea, DxButton } from "devextreme-vue";
    export default defineComponent({
        components: {
            DxTextArea,
            DxButton,
        },
        data() {
            return {
                inputText: '',
                instructionText: '',
                aiResponse: '',
                apiUrl: 'http://localhost:5000/api/TextEditAPI',
            };
        },
        methods: {
            async submitRequest() {
                const requestBody = {
                    text: this.inputText,
                    instruction: this.instructionText,
                };

                try {
                    const response = await fetch(this.apiUrl, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify(requestBody),
                    });

                    const responseData = await response.json();
                    this.aiResponse = responseData;
                } catch (error) {
                    console.error(error);
                    // Handle error scenario
                }
            },
        },
    });
</script>

<style scoped>
    .container {
        margin-top: 20px;
    }
</style>
